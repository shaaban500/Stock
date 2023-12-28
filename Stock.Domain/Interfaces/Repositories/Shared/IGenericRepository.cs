using System.Linq.Expressions;
using Stock.Domain.Entities.Shared;

namespace Stock.Domain.Interfaces.Repositories.Shared
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        Task<T> GetByIdAsync(long id);

        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null);

        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);

        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    params Expression<Func<T, object>>[] includes);

        Task<T> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);

    }

}
