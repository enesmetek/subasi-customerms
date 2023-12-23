using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Requests
{
    public class GetAllAddressesQueryRequest : IRequest<List<AddressQueryResponse>>
    {
    }
}
