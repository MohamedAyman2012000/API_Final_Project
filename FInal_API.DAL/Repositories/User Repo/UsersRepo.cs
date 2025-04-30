using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Context;
using Final_API.DAL.Models;

namespace Final_API.DAL.Repositories.User_Repo
{
    public class UsersRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;
        public UsersRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        async Task<CustomUser> IUserRepo.GetByIdAsync(string userId)
        {
            return  _context.Users.Find(userId);
        }
    }
}
