using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Generic_Repo;

namespace Final_API.DAL.Repositories.Bugs_Repo
{
    public interface IBugsRepo:IGenericRepo<Bug>
    {
        Task<Bug> GetWithDetails(int ID);
    }
}
