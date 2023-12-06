using DataAccessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PokemonContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository()
        {
            _context = new();
            _dbSet = _context.Set<T>();
        }


        public  bool Add(T entity)
        {
            _dbSet.Add(entity);
            int success = _context.SaveChanges();
            return success == 1;
        }

        public  IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public  T? GetById(int? id)
        {

            return _dbSet.Find(id);
        }

        public  bool Remove(T entity)
        {
            _dbSet.Remove(entity);
            int success =  _context.SaveChanges();
            return success == 1;
        }

        public  bool Update(T entity)
        {
            _dbSet.Update(entity);
            int success = _context.SaveChanges();
            return success == 1;


        }

        
    }
}
