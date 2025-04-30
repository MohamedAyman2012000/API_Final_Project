using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.BL.DTOs.ProjectDTOs;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Projects_Repo;
using Final_API.DAL.UnitOfWork;

namespace Final_API.BL.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        async Task IProjectService.AddAsync(AddProjectDto projectDto)
        {
            var project = new Project() { Name = projectDto.Name };
            _unitOfWork.ProjectsRepo.Add(project);
            await _unitOfWork.SaveChanges();
        }

        async Task<IEnumerable<ReadProjectDto>> IProjectService.GetAll()
        {
            var projects = await _unitOfWork.ProjectsRepo.GetAll();
            return projects.Select(x=> new ReadProjectDto() { Id = x.Id,Name = x.Name});
        }

        async Task<ReadProjectDetailsDto> IProjectService.GetByDetails(int id)
        {
            var project = await _unitOfWork.ProjectsRepo.GetWithDetails(id);
            if(project!=null)
            {
                return new ReadProjectDetailsDto() { Id = project.Id, Name = project.Name, Bugs = project.Bugs };
            }
            return null;
        }
    }
}
