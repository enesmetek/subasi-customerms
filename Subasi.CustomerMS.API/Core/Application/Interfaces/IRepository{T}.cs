using Subasi.CustomerMS.API.Core.Domain.Abstract;
using System.Linq.Expressions;

namespace Subasi.CustomerMS.API.Core.Application.Interface
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task UpdateAsync(T updatedEntity);
        Task DeleteAsync(T entity);
    }
}
