using MediatR;
using Subasi.CustomerMS.API.Core.Application.DTOs.AddressDTOs;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAllAddressesQueryRequest : IRequest<List<AddressListDTO>>
    {
    }
}
