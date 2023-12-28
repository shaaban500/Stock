using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Stock.Domain.Entities.Shared;
using Stock.Domain.Interfaces.Repositories.Shared;

namespace Stock.Infrastructure.Repositories.Shared
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _context;
        public DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }


        public async Task<T> GetByIdAsync(long id)
        {
            return await _context.Set<T>().Where(r => r.IsDeleted != true && r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null)
        {
            var entity = _context.Set<T>().Where(e => e.IsDeleted != true);

            if (filter != null)
                entity = entity.Where(filter);

            return await entity.FirstOrDefaultAsync();

        }

        public virtual async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            var entity = _context.Set<T>().Where(e => e.IsDeleted != true);

            if (filter != null)
            {
                entity = entity.Where(filter);
            }

            if (includes?.Length > 0)
            {
                foreach (var include in includes)
                {
                    entity = entity.Include(include);
                }
            }

            return await entity.FirstOrDefaultAsync();
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(r => r.IsDeleted != true);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes?.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }


        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }



        public async Task<int> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

    }
}
