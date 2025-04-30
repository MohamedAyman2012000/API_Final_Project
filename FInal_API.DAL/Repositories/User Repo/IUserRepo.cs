using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Models;

namespace Final_API.DAL.Repositories.User_Repo
{
    public interface IUserRepo
    {
        Task<CustomUser> GetByIdAsync(string userId);
    }
}
