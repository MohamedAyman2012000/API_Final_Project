using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Context;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Generic_Repo;
using Microsoft.EntityFrameworkCore;

namespace Final_API.DAL.Repositories.Bugs_Repo
{
    public class BugsRepo : GenericRepo<Bug>,IBugsRepo
    {
        private ApplicationDbContext _context;
        public BugsRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        async Task<Bug?> IBugsRepo.GetWithDetails(int ID)
        {
            var bug = _context.Bugs.Include(x => x.Attachments).Include(x => x.UserBugs).ThenInclude(ub => ub.User).Include(x => x.Project).FirstOrDefault(x => x.Id == ID);
            return bug;
        }
    }
}
