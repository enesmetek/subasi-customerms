using MediatR;
using Subasi.CustomerMS.API.Core.Application.DTOs.CustomerDTOs;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries
{
    public class GetCustomerQueryRequest : IRequest<CustomerListDTO>
    {
        public GetCustomerQueryRequest(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
