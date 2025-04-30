using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Models;

namespace Final_API.BL.DTOs.BugsDTOs
{
    public class UserBugDTO
    {
        public CustomUser? User { get; set; }
        public Bug? Bug { get; set; }
        public bool IsAlreadyAssigned { get; set; }

    }
}
