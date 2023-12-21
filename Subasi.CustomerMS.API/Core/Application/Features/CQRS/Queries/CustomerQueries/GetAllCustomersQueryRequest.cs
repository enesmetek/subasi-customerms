using MediatR;
using Subasi.CustomerMS.API.Core.Application.DTOs.CustomerDTOs;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries
{
    public class GetAllCustomersQueryRequest : IRequest<List<CustomerListDTO>>
    {
    }
}
