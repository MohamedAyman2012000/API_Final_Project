using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Context;
using Final_API.DAL.Models;
using Final_API.DAL.Repositories.Bugs_Repo;
using Microsoft.EntityFrameworkCore;

namespace Final_API.DAL.Repositories.Generic_Repo
{
    public class GenericRepo<T>:IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        async void IGenericRepo<T>.Add(T bug)
        {
            _context.Set<T>().Add(bug);
        }

        async Task<IEnumerable<T>> IGenericRepo<T>.GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        async Task<T> IGenericRepo<T>.GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        void IGenericRepo<T>.Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
