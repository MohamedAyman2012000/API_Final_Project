using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_API.DAL.Models
{
    public class UserBug
    {
        public string UserId { get; set; }
        public CustomUser User { get; set; }
        public int BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
