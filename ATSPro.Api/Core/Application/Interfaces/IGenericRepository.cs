using System.Linq.Expressions;

namespace ATSPro.Api.Core.Application.Interfaces
{
    public interface IGenericRepository<T>where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);

        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);
    }
}
