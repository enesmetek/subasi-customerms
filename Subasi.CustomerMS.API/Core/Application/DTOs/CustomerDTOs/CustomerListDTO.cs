using Subasi.CustomerMS.API.Core.Application.DTOs.AddressDTOs;

namespace Subasi.CustomerMS.API.Core.Application.DTOs.CustomerDTOs
{
    public class CustomerListDTO
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<AddressListDTO>? Addresses { get; set; }
    }
}
