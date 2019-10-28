using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebSitePerformance.Dal.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Delete(TEntity entity);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> GetById(int Id);
        Task<IEnumerable<TEntity>> GetBy(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
        IQueryable<TEntity> GetItems();
    }
}
