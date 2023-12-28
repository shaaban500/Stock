using System.Linq.Expressions;
using Stock.Domain.Entities.Shared;

namespace Stock.Domain.Interfaces.Repositories.Shared
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllIQueryable();
        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByIdAsync(long? id = null, Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<TResult>> GetAllWithSelectorAsync<TResult>(Expression<Func<T, TResult>> selector,
                                                                        Expression<Func<T, bool>> filter = null,
                                                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                                        params Expression<Func<T, object>>[] includes);

        IQueryable<TResult> GetAllWithSelector<TResult>(Expression<Func<T, TResult>> selector,
                                                                            Expression<Func<T, bool>> filter = null,
                                                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                                            params Expression<Func<T, object>>[] includes);

        Task<TResult?> GetPropertyWithSelectorAsync<TResult>(Expression<Func<T, TResult>> selector,
                                                                        Expression<Func<T, bool>> filter = null,
                                                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                                        params Expression<Func<T, object>>[] includes);

        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<T> AddAsync(T entity);
        T Add(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entities);
        Task<int> DeleteRangeAsync(List<T> entities);
        Task<int> UpdateRangeAsync(List<T> entities);
        List<TSource> OrderBy<TSource>(List<TSource> source, string propertyName);
        int GetTotalRecords();



        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            string includeProperties = "",
                            int? take = null);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            string includeProperties = "",
                                            int? take = null);

        T GetEntity();

        IEnumerable<T> GetPaged(int pageIndex, int pageCount, Expression<Func<T, bool>> filter = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeProperties = "");

        Task<IEnumerable<T>> GetPagedAsync(int pageIndex,
                                            int pageCount, Expression<Func<T, bool>> filter = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetPagedIQueryable(int pageIndex, int pageCount, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithRelatedEntities(string includeProperties = "");



        Task<T> GetEntityAsync(Expression<Func<T, bool>> filter = null);

    }

}
