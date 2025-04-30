using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Models;

namespace Final_API.DAL.Repositories.Generic_Repo
{
    public interface IGenericRepo<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public void Add(T entity);
        public void Remove(T entity);

    }
}
