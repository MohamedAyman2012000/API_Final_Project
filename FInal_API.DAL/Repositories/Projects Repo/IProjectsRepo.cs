using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Generic_Repo;

namespace Final_API.DAL.Repositories.Projects_Repo
{
    public interface IProjectsRepo:IGenericRepo<Project>
    {
        Task<Project> GetWithDetails(int projectId);
    }
}
