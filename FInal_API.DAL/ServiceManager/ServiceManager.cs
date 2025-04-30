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
using Final_API.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Final_API.DAL.ServiceManager
{
    public static class ServiceManager
    {
        public static void AddDALServices(this IServiceCollection services,IConfigurationManager config)
        {
            var ConnectionSteing = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ConnectionSteing);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IProjectsRepo, ProjectsRepo>();
            services.AddScoped<IBugsRepo, BugsRepo>();
            services.AddScoped<IAttachmentsRepo, AttachmentsRepo>();
            services.AddScoped<IUserRepo,UsersRepo>();
            services.AddScoped<IUserBugsRepo,UserBugsRepo>();



        }
    }
}
