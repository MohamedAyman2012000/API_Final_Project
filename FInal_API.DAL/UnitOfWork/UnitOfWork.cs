
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Context;
using Final_API.DAL.Repositories.Attachments_Repo;
using Final_API.DAL.Repositories.Bugs_Repo;
using Final_API.DAL.Repositories.Projects_Repo;
using Final_API.DAL.Repositories.User_Repo;
using Final_API.DAL.Repositories.UserBugsRepo;

namespace Final_API.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context, IProjectsRepo projectsRepo,IBugsRepo bugsRepo,IAttachmentsRepo attachmentsRepo,IUserRepo userRpo,IUserBugsRepo userBugsRepo)
        {
            _context = context;
            BugsRepo = bugsRepo;
            AttachmentsRepo = attachmentsRepo;
            ProjectsRepo = projectsRepo;
            UsersRepo = userRpo;
            UserBugsRepo = userBugsRepo;
        }
        public IBugsRepo BugsRepo { get; }
        public IUserBugsRepo UserBugsRepo { get; }
        public IProjectsRepo ProjectsRepo { get; }
        public IAttachmentsRepo AttachmentsRepo { get; }
        public IUserRepo UsersRepo { get; }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
