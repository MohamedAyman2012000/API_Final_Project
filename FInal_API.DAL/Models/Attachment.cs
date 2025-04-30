using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_API.DAL.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int BugId { get; set; }
        public Bug Bug { get; set; }

    }
}
