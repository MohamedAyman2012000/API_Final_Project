using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_API.DAL.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bug> Bugs { get; set; }

    }
}
