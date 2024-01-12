using Microsoft.EntityFrameworkCore;
using Subasi.CustomerMS.API.Core.Application.Interfaces;
using Subasi.CustomerMS.API.Core.Domain.Concrete;
using Subasi.CustomerMS.API.Persistance.Context;

namespace Subasi.CustomerMS.API.Persistance.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly SubasiCustomerMSDbContext _context;
        public AddressRepository(SubasiCustomerMSDbContext context) : base(context)
        {
            _context = context;
        }

       public async Task<List<Address>?> GetAllAddressesByCustomerID(Guid id)
        {
            return await _context.Set<Address>().Where(x => x.CustomerID == id).AsNoTracking().ToListAsync();
        }
    }
}
