using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Requests
{
    public class GetAllCustomersQueryRequest : IRequest<List<CustomerQueryResponse>>
    {
    }
}
