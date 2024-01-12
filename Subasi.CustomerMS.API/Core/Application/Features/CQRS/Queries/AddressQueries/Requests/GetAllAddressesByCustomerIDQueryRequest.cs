using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Requests
{
    public class GetAllAddressesByCustomerIDQueryRequest : IRequest<List<AddressQueryResponse>>
    {
        public GetAllAddressesByCustomerIDQueryRequest(Guid id)
        {
            ID = id;
        }
        public Guid ID { get; set; }
    }
}
