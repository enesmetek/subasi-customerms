using MediatR;
using Subasi.CustomerMS.API.Core.Application.DTOs.AddressDTOs;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressQueryRequest : IRequest<AddressListDTO>
    {
        public GetAddressQueryRequest(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
