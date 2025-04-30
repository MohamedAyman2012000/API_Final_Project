using Final_API.DAL.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Final_API.DAL.Models;
using Final_API.DAL.ServiceManager;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using API_Final_Project.API_Constants;
using Final_API.BL.ExtensionManager;
using Final_API.BL.Services.ProjectServices;
using Final_API.DAL.UnitOfWork;
using Final_API.DAL.Repositories.Projects_Repo;
namespace API_Final_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddDALServices(builder.Configuration);
            builder.Services.AddBLServices();

            builder.Services.AddIdentityCore<CustomUser>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            }) .AddEntityFrameworkStores<ApplicationDbContext>();

             builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var secretKey = builder.Configuration.GetValue<string>("SecretKey")!;

                var secretKeyInBytes = Encoding.UTF8.GetBytes(secretKey);
                var key = new SymmetricSecurityKey(secretKeyInBytes);

                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key,
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(ConstantClasses.ConstantRoles.Manger,
                    builder => builder
                        .RequireClaim(ClaimTypes.Role, ConstantClasses.ConstantRoles.Manger)
                        .RequireClaim(ClaimTypes.NameIdentifier)
                );

                options.AddPolicy(ConstantClasses.ConstantRoles.Developer,
                    builder => builder
                        .RequireClaim(ClaimTypes.Role, ConstantClasses.ConstantRoles.Developer)
                        .RequireClaim(ClaimTypes.NameIdentifier)
                ); 
                
                options.AddPolicy(ConstantClasses.ConstantRoles.Tester,
                    builder => builder
                        .RequireClaim(ClaimTypes.Role, ConstantClasses.ConstantRoles.Tester)
                        .RequireClaim(ClaimTypes.NameIdentifier)
                );

            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
