using API_Final_Project.API_Constants;
using Final_API.BL.DTOs.AttachmentsDTOs;
using Final_API.BL.DTOs.BugsDTOs;
using Final_API.BL.DTOs.ProjectDTOs;
using Final_API.BL.DTOs.UserDTOs;
using Final_API.BL.Services.AttachmentService;
using Final_API.BL.Services.BugServices;
using Final_API.BL.Services.ProjectServices;
using Final_API.BL.Services.UserBugServices;
using Final_API.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Final_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugsController : ControllerBase
    {
        private readonly IBugService _bugService;
        private readonly IUserBugService _userBugService;
        private readonly IAttachmentService _attachmentService;
        public BugsController(IBugService bugService, IUserBugService userBugService, IAttachmentService attachmentService)
        {
            _bugService = bugService;
            _userBugService = userBugService;
            _attachmentService = attachmentService;

        }

        [HttpGet]
        [Authorize]
        public async Task<Ok<List<ReadBugDto>>> GetAll()
        {
            var Bugs = (await _bugService.GetAll()).ToList();
            return TypedResults.Ok(Bugs);
        }

        [HttpPost]
        [Authorize(Policy = ConstantClasses.ConstantRoles.Developer)]
        public async Task<NoContent> AddBug(AddBugDto BugDto)
        {
            await _bugService.AddAsync(BugDto);
            return TypedResults.NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Policy = ConstantClasses.ConstantRoles.Manger)]
        public async Task<Results<Ok<ReadBugDetailsDto>, BadRequest>> GetDetails(int id)
        {
            var Bug = await _bugService.GetByDetails(id);
            if (Bug == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(Bug);
        }



        [HttpPost("{id}/assignees")]
        [Authorize(Policy = ConstantClasses.ConstantRoles.Developer)]
        public async Task<Results<NotFound, NoContent, BadRequest>> AssignUserToBug([FromRoute] int id, [FromBody] AssignUserDto dto)
        {
            var userbugDto = await _userBugService.GetUserWithBug(id, dto);
            var user = userbugDto.User;
            var bug = userbugDto.Bug;
            if (user == null || bug == null) return TypedResults.NotFound();
            if (userbugDto.IsAlreadyAssigned) return TypedResults.BadRequest();

            var UserBug = new UserBug() { BugId = id, UserId = dto.UserID };
            await _userBugService.AddAsync(UserBug);
            return TypedResults.NoContent();
        }

        [HttpDelete("{id}/assignees/{userId}")]
        [Authorize(Policy = ConstantClasses.ConstantRoles.Manger)]
        public async Task<NoContent> Delete(int id, string userId)
        {
            await _userBugService.DeleteAsync(id, userId);
            return TypedResults.NoContent();
        }


        [HttpGet("{id}/attachments")]
        [Authorize(Policy = ConstantClasses.ConstantRoles.Manger)]
        public async Task<Results<Ok<IEnumerable<ReadAttachmentDto>>, BadRequest>> GetAttachments(int id)
        {
            var result = await _attachmentService.GetBugAttachments(id);
            return TypedResults.Ok(result);

        }

        [HttpPost("{id}/attachments")]
        [Authorize(Policy = ConstantClasses.ConstantRoles.Developer)]
        public async Task<NoContent> AddAttachments(AddAttachmentDto attDto)
        {
            await _attachmentService.AddBugAttachment(attDto);
            return TypedResults.NoContent();
        }


        [HttpDelete("{id}/attachments/{attachmentId}")]
        [Authorize(Policy = ConstantClasses.ConstantRoles.Manger)]
        public async Task<Results<NoContent,BadRequest>> AddAttachments(int id, int attachmentId)
        {
            var Deletedattachment= await _attachmentService.DeleteBugAttachment(id, attachmentId);
            if (Deletedattachment != null)
            {
              return TypedResults.NoContent();
            }
            return TypedResults.BadRequest();
        }
    }
}
