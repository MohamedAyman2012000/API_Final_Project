using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.BL.DTOs.BugsDTOs;
using Final_API.BL.DTOs.UserDTOs;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.User_Repo;

namespace Final_API.BL.Services.UserBugServices
{
    public interface IUserBugService
    {
        Task<UserBugDTO> GetUserWithBug(int bugId, AssignUserDto user);
        Task AddAsync(UserBug userRepo);
        Task DeleteAsync(int bugId, string UserId);
    }
}
