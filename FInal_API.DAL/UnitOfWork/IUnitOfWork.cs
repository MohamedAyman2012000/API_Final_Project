using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Attachments_Repo;
using Final_API.DAL.Repositories.Bugs_Repo;
using Final_API.DAL.Repositories.Projects_Repo;
using Final_API.DAL.Repositories.User_Repo;
using Final_API.DAL.Repositories.UserBugsRepo;

namespace Final_API.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IBugsRepo BugsRepo { get; }
        public IProjectsRepo ProjectsRepo { get; }
        public IAttachmentsRepo AttachmentsRepo { get; }
        public IUserRepo  UsersRepo { get; }
        public IUserBugsRepo UserBugsRepo { get; }
        public Task SaveChanges();
    }
}
