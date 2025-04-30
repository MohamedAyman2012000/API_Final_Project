using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Context;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Generic_Repo;

namespace Final_API.DAL.Repositories.Attachments_Repo
{
    public class AttachmentsRepo:GenericRepo<Attachment>,IAttachmentsRepo
    {
        private readonly ApplicationDbContext _context;
        public AttachmentsRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

         async  Task<IEnumerable<Attachment>> IAttachmentsRepo.GetWithBugID(int bugId)
         {
           var AttachmentsLst =  _context.Attachments.Where(x => x.BugId == bugId).AsEnumerable();

            return AttachmentsLst;
         }
    }
}
