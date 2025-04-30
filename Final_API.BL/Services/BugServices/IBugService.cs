using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.BL.DTOs.BugsDTOs;
using Final_API.BL.DTOs.ProjectDTOs;
using Final_API.BL.DTOs.UserDTOs;

namespace Final_API.BL.Services.BugServices
{
    public interface IBugService
    {
        Task<IEnumerable<ReadBugDto>> GetAll();
        Task AddAsync(AddBugDto bug);
        Task<ReadBugDetailsDto> GetByDetails(int id);
        
    }
}
