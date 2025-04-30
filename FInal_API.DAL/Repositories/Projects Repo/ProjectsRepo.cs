using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Context;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Generic_Repo;
using Microsoft.EntityFrameworkCore;

namespace Final_API.DAL.Repositories.Projects_Repo
{
    public class ProjectsRepo:GenericRepo<Project>,IProjectsRepo
    {
        private readonly ApplicationDbContext _context;
        public ProjectsRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        async Task<Project?> IProjectsRepo.GetWithDetails(int projectId)
        {
            return await _context.Projects .Include(p => p.Bugs).FirstOrDefaultAsync(p => p.Id == projectId);
        }
    }
}
