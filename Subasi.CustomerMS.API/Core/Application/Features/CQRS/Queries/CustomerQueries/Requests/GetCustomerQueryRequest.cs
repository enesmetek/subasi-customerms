using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Requests
{
    public class GetCustomerQueryRequest : IRequest<CustomerQueryResponse>
    {
        public GetCustomerQueryRequest(Guid id)
        {
            ID = id;
        }
        public Guid ID { get; set; }
    }
}
