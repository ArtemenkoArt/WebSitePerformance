using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebSitePerformance.Dal.Context;
using WebSitePerformance.Dal.Entities;

namespace WebSitePerformance.Dal.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntities
    {
        internal readonly PageDataContext _context;
        internal readonly DbSet<T> _dbSet;

        public GenericRepository(PageDataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetItems()
        {
            return _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var list = await _dbSet.ToListAsync();
            return list;
        }

        public async Task<T> Add(T entity)
        {
            var result = _dbSet.Add(entity);
            await SaveChangesAsync();
            return result;
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<T> GetById(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(item => item.Id == Id);
        }

        public virtual async Task<IEnumerable<T>> GetBy(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            var existing = await _dbSet.FindAsync(entity.Id);

            if (existing != null)
            {
                _context.Entry(existing).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
