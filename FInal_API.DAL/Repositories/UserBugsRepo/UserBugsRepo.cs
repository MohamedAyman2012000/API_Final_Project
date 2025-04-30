using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Context;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Generic_Repo;

namespace Final_API.DAL.Repositories.UserBugsRepo
{
    public class UserBugsRepo :GenericRepo<UserBug>, IUserBugsRepo
    {
        private readonly ApplicationDbContext _context;
        public UserBugsRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
