using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Requests
{
    public class GetAddressQueryRequest : IRequest<AddressQueryResponse>
    {
        public GetAddressQueryRequest(Guid id)
        {
            ID = id;
        }
        public Guid ID { get; set; }
    }
}
