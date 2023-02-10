using RobotsManagement.Data.Context;
using RobotsManagement.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly RobotsManagementDbContext _context;
        public GenericRepository(RobotsManagementDbContext context)
        {
            _context = context;
        }

        bool IGenericRepository<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }

        bool IGenericRepository<T>.DeleteById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        List<T> IGenericRepository<T>.GetAll()
        {
            return _context.Set<T>().ToList();
        }

        T IGenericRepository<T>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        void IGenericRepository<T>.Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();

        }
    }
}
