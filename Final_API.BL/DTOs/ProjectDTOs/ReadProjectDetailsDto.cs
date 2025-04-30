using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Models;

namespace Final_API.BL.DTOs.ProjectDTOs
{
    public class ReadProjectDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Bug> Bugs { get; set; }
    }
}
