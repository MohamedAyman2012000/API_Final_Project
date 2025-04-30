using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_API.BL.DTOs.AttachmentsDTOs
{
    public class AddAttachmentDto
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int BugId { get; set; }
    }
}
