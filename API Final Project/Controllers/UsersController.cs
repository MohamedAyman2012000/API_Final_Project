using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API_Final_Project.API_Constants;
using Final_API.BL.DTOs;
using Final_API.DAL.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API_Final_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<CustomUser>   _userManager;
        public UsersController(IConfiguration configuration, UserManager<CustomUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<Results<Ok<TokenDto>, UnauthorizedHttpResult>> Login(LoginCredentials credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.UserName);
            if (user is null)
            {
                return TypedResults.Unauthorized();
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, credentials.Password);

            if (!isPasswordValid)
            {
                return TypedResults.Unauthorized();
            }

            var claims = await _userManager.GetClaimsAsync(user);

            var tokenDto = GenerateToken(claims.ToList());

            return TypedResults.Ok(tokenDto);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Results<NoContent, BadRequest<List<string>>>> Register([FromBody]RegisterDto registerDto)
        {
            var user = new CustomUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
            };

            var creationResult = await _userManager.CreateAsync(user, registerDto.Password);
            if (!creationResult.Succeeded)
            {
                var errors = creationResult.Errors.Select(e => e.Description).ToList();

                return TypedResults.BadRequest(errors);
            }

            var claims = new List<Claim>
            {
                 new (ClaimTypes.NameIdentifier, user.Id),
                 new (ClaimTypes.Email, user.Email),
                 new(ClaimTypes.Role,ConstantClasses.ConstantRoles.Developer)
            };

            await _userManager.AddClaimsAsync(user, claims);

            return TypedResults.NoContent();

        }

        private TokenDto GenerateToken(List<Claim> claims)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey")!;

            var secretKeyInBytes = Encoding.UTF8.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(secretKeyInBytes);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256
                )
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDto() { Token = tokenString, ExpireDate= token.ValidTo };
        }

    }
}
