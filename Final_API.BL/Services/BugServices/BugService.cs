using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.BL.DTOs.BugsDTOs;
using Final_API.BL.DTOs.UserDTOs;
using Final_API.DAL.Models;
using Final_API.DAL.UnitOfWork;

namespace Final_API.BL.Services.BugServices
{
    public class BugService : IBugService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BugService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        async Task IBugService.AddAsync(AddBugDto bug)
        {
            var Bug = new Bug() { Title = bug.Title, Description = bug.Description, ProjectId =bug.projectID};
            _unitOfWork.BugsRepo.Add(Bug);
            await _unitOfWork.SaveChanges();
        }

        async Task<IEnumerable<ReadBugDto>> IBugService.GetAll()
        {
            var bugLst = await _unitOfWork.BugsRepo.GetAll();
            return bugLst.Select(x => new ReadBugDto() { Title = x.Title, Description = x.Description });
        }

        async Task<ReadBugDetailsDto?> IBugService.GetByDetails(int id)
        {
            var Bug = await _unitOfWork.BugsRepo.GetWithDetails(id);
            if (Bug == null)
                return null;

            var bugDto = new ReadBugDetailsDto
            {
                Title = Bug.Title,
                Descreption = Bug.Description,
                Project = new ProjectDTO
                {
                    Name = Bug.Project?.Name
                },

                Assignees = Bug.UserBugs?.Select(ub => new AssigneeDTO
                {
                    Id = ub.UserId,
                    Name = ub.User.UserName 
                }).ToList(),

                Attachments = Bug.Attachments?.Select(a => new AttachmentDTO
                {
                    Id = a.Id.ToString(),
                    FileName = a.FileName,
                    FilePath = a.FilePath
                }).ToList()
            };

            return bugDto;
        }

       
    }
}
