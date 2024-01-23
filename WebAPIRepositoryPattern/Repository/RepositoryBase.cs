using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using WebAPIRepositoryPattern.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPIRepositoryPattern.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase, new()
    {
        private ApplicationDBContext _RepositoryContext { get; set; }
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(ApplicationDBContext RepositoryContext)
        {
            this._RepositoryContext = RepositoryContext;
            this._dbSet = RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return this._RepositoryContext.Set<T>().AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _RepositoryContext.Set<T>().ToListAsync().ConfigureAwait(false);

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _RepositoryContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync().ConfigureAwait(false);

        }

        public IQueryable<T> FindbyCondition(Expression<Func<T, bool>> expression)
        {
            return _RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            var query = _RepositoryContext.Set<T>().AsQueryable();

            var queryable = query.Where(expression).AsNoTracking();

            var results = await queryable.ToListAsync();

            return results;
        }

        public async Task AddAsync(T entity)
        {
            await _RepositoryContext.Set<T>().AddAsync(entity);
            await _RepositoryContext.SaveChangesAsync();
        }


        public async Task UpdateAsync(T entity, int id)
        {
            EntityEntry entityEntry = _RepositoryContext.Entry<T>(entity);
            _RepositoryContext.ChangeTracker.Clear();
            entityEntry.State = EntityState.Modified;
            await _RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T enty, int id)
        {
            var entity = await _RepositoryContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _RepositoryContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _RepositoryContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _RepositoryContext.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
