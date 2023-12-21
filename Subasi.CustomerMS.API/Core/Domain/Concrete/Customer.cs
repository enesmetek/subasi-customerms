using Subasi.CustomerMS.API.Core.Domain.Abstract;

namespace Subasi.CustomerMS.API.Core.Domain.Concrete
{
    public class Customer : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}
