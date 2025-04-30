using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_API.DAL.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<UserBug> UserBugs { get; set; }
        public ICollection<Attachment> Attachments { get; set; }


    }
}
