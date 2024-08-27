using System.Linq.Expressions;

namespace CaExam.Interfaces.RepositoryInterfaces
{

    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
        Task MarkPropertyAsModifiedAsync<T>(T entity, string propertyName) where T : class;

    }

}
