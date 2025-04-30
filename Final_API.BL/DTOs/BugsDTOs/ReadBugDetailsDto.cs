using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_API.BL.DTOs.BugsDTOs
{
    public class ReadBugDetailsDto
    {
        public string Title { get; set; }
        public string Descreption { get; set; }
        public ProjectDTO Project { get; set; }
        public List<AssigneeDTO> Assignees { get; set; }
        public List<AttachmentDTO> Attachments { get; set; }
    }

    public class AssigneeDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class AttachmentDTO
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

    public class ProjectDTO
    {
        public string Name { get; set; }
    }

}
