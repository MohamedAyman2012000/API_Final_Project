using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Generic_Repo;

namespace Final_API.DAL.Repositories.Attachments_Repo
{
    public interface IAttachmentsRepo:IGenericRepo<Attachment>
    {
        Task<IEnumerable<Attachment>> GetWithBugID(int bugId);
    }
}
