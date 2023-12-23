using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Requests
{
    public class GetCustomerQueryRequest : IRequest<CustomerQueryResponse>
    {
        public GetCustomerQueryRequest(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
