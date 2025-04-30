using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.BL.DTOs.AttachmentsDTOs;
using Final_API.DAL.Models;
using Final_API.DAL.UnitOfWork;

namespace Final_API.BL.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttachmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task IAttachmentService.AddBugAttachment(AddAttachmentDto attDto)
        {
            var attachment = new Attachment() { BugId = attDto.BugId, FileName = attDto.FileName, FilePath = attDto.FilePath };
            _unitOfWork.AttachmentsRepo.Add(attachment);
            await _unitOfWork.SaveChanges();
        }

        async Task<Attachment> IAttachmentService.DeleteBugAttachment(int bugID, int attId)
        {
            var attachment = await _unitOfWork.AttachmentsRepo.GetById(attId);
            if (attachment!=null)
            {
                _unitOfWork.AttachmentsRepo.Remove(attachment);
                await _unitOfWork.SaveChanges();
            }
              return attachment!;
        }

        async Task<IEnumerable<ReadAttachmentDto>> IAttachmentService.GetBugAttachments(int Id)
        {
            var attachmentsDTOs = (await _unitOfWork.AttachmentsRepo.GetWithBugID(Id)).ToList().Select(x=>new ReadAttachmentDto()
            {
                Id = x.Id,
                FileName = x.FileName,
                FilePath=x.FilePath,
            });
            return attachmentsDTOs.ToList();
        }
    }
}
