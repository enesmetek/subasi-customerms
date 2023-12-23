using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Responses
{
    public class CustomerQueryResponse
    {
        public int ID { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<AddressQueryResponse>? Addresses { get; set; }
    }
}
