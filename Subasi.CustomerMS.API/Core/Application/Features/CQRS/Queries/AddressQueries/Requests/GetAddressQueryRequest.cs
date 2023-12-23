using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Requests
{
    public class GetAddressQueryRequest : IRequest<AddressQueryResponse>
    {
        public GetAddressQueryRequest(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
