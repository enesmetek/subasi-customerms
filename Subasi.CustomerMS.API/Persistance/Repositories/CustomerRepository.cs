using Microsoft.EntityFrameworkCore;
using Subasi.CustomerMS.API.Core.Application.Interfaces;
using Subasi.CustomerMS.API.Core.Domain.Concrete;
using Subasi.CustomerMS.API.Persistance.Context;

namespace Subasi.CustomerMS.API.Persistance.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly SubasiCustomerMSDbContext _context;
        public CustomerRepository(SubasiCustomerMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer?> GetCustomerWithAddress(Guid id)
        {
            return await _context.Set<Customer>().Where(x => x.ID == id).Include(x => x.Addresses).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<Customer>?> GetAllCustomersWithAddresses()
        {
            return await _context.Set<Customer>().Include("Addresses").AsNoTracking().ToListAsync();
        }
        
    }
}
