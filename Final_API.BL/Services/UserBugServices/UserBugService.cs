using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.BL.DTOs.BugsDTOs;
using Final_API.BL.DTOs.UserDTOs;
using Final_API.BL.Services.BugServices;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.User_Repo;
using Final_API.DAL.Repositories.UserBugsRepo;
using Final_API.DAL.UnitOfWork;

namespace Final_API.BL.Services.UserBugServices
{
    public class UserBugService:IUserBugService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserBugService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task IUserBugService.AddAsync(UserBug userBug)
        {
             _unitOfWork.UserBugsRepo.Add(userBug);
            await _unitOfWork.SaveChanges();
        }

        async Task IUserBugService.DeleteAsync(int bugId, string UserId)
        {
            var UserBug = (await _unitOfWork.UserBugsRepo.GetAll()).ToList().SingleOrDefault(x => x.UserId == UserId && x.BugId == bugId);
            if (UserBug != null)
            {
                _unitOfWork.UserBugsRepo.Remove(UserBug);
                await _unitOfWork.SaveChanges();
            }
        }

        async Task<UserBugDTO> IUserBugService.GetUserWithBug(int bugId, AssignUserDto userdto)
        {
            var user = await _unitOfWork.UsersRepo.GetByIdAsync(userdto?.UserID);
            var bug = await _unitOfWork.BugsRepo.GetById(bugId);
            var userBugs = (await _unitOfWork.UserBugsRepo.GetAll()).ToList();
            var isAssigned = false;
            if (userBugs.Any(x => x.UserId == userdto.UserID && x.BugId == bugId)) isAssigned = true;
            var userbugDTO = new UserBugDTO() { User = user, Bug = bug, IsAlreadyAssigned = isAssigned };
            return userbugDTO;
        }
    }
}
