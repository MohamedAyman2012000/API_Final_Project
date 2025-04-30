using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.BL.Services.AttachmentService;
using Final_API.BL.Services.BugServices;
using Final_API.BL.Services.ProjectServices;
using Final_API.BL.Services.UserBugServices;
using Final_API.DAL.Context;
using Final_API.DAL.Repositories.Projects_Repo;
using Final_API.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Final_API.BL.ExtensionManager
{
    public static class ServiceManager
    {
        public static void AddBLServices(this IServiceCollection services)
        {      
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserBugService, UserBugService>();
            services.AddScoped<IBugService, BugService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
        }
    }
}
