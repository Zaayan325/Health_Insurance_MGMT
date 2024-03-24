using App.DataAccessLibrary.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HealthInsuranceMGMT _context;
        private DbSet<T> _dbSet;

        public Repository(HealthInsuranceMGMT context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()  
        {
            return _dbSet.ToList();
        }
        public async Task save()
        {
            await _context.SaveChangesAsync();
        }
        public T? GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }
        public async Task<T?> GetTAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }


    }
}
