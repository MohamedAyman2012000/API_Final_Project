using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.BL.DTOs.ProjectDTOs;
using Final_API.DAL.Models;

namespace Final_API.BL.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<IEnumerable<ReadProjectDto>> GetAll();
        Task AddAsync(AddProjectDto project);
        Task<ReadProjectDetailsDto> GetByDetails(int id);


    }
}
