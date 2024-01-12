using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<List<Address>?> GetAllAddressesByCustomerID(Guid id);
    }
}
