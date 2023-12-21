using Subasi.CustomerMS.API.Core.Domain.Abstract;
using System.Linq.Expressions;

namespace Subasi.CustomerMS.API.Core.Application.Interface
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllByFilerAsync(Expression<Func<T, bool>> filer);
        Task CreateAsync(T entity);
        Task UpdateAsync(T updatedEntity);
        Task DeleteAsync(T entity);
    }
}
