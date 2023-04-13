using System.Linq;
using System.Linq.Expressions;

namespace WebAPIRepositoryPattern.Repository
{
    public interface IRepositoryBase <T> where T : class, IEntityBase, new()
    {
        IQueryable<T> FindAll ();

        IQueryable<T> FindbyCondition(Expression<Func<T, bool>> expression);
        //Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task UpdateAsync(T entity, int id);

        Task DeleteAsync(T entity, int id);
    }
}
