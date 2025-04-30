using API_Final_Project.API_Constants;
using Final_API.BL.DTOs.ProjectDTOs;
using Final_API.BL.Services.ProjectServices;
using Final_API.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Final_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController:ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Authorize]
        public async Task<Ok<List<ReadProjectDto>>> GetAll()
        {
            var projects =( await _projectService.GetAll()).ToList();
            return TypedResults.Ok(projects);
        }

        [HttpPost]
        [Authorize(Policy = ConstantClasses.ConstantRoles.Developer)]
        public async Task<NoContent> AddProject(AddProjectDto projectDto)
        {
            await _projectService.AddAsync(projectDto);
            return TypedResults.NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Policy =ConstantClasses.ConstantRoles.Manger)]
        public async Task<Results<Ok<ReadProjectDetailsDto>,BadRequest>> GetDetails(int id)
        {
            var project = await _projectService.GetByDetails(id);
            if (project == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(project);
        }
    }
}
