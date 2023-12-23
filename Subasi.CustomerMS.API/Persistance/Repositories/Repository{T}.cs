using Microsoft.EntityFrameworkCore;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Abstract;
using Subasi.CustomerMS.API.Persistance.Context;
using System.Linq.Expressions;

namespace Subasi.CustomerMS.API.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly SubasiCustomerMSDbContext _context;

        public Repository(SubasiCustomerMSDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T updatedEntity)
        {
            _context.Set<T>().Update(updatedEntity);
            await _context.SaveChangesAsync();
        }
    }
}
