using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.BL.DTOs.AttachmentsDTOs;
using Final_API.BL.DTOs.BugsDTOs;
using Final_API.DAL.Models;

namespace Final_API.BL.Services.AttachmentService
{
    public interface IAttachmentService
    {
        Task<IEnumerable<ReadAttachmentDto>> GetBugAttachments(int Id);
        Task AddBugAttachment(AddAttachmentDto attDto);
        Task<Attachment> DeleteBugAttachment(int bugID,int attId);
    }
}
