using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Final_API.DAL.Models
{
    public class CustomUser : IdentityUser
    {
        public ICollection<UserBug> UserBugs { get; set; }

    }
}
