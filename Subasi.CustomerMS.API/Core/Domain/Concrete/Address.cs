using Subasi.CustomerMS.API.Core.Domain.Abstract;
using Subasi.CustomerMS.API.Core.Domain.Enums;

namespace Subasi.CustomerMS.API.Core.Domain.Concrete
{
    public class Address : BaseEntity
    {
        public AddressType AddressType { get; set; }
        public string? AddressLine { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }
    }
}
