using AutoMapper;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Responses;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Mappings.AutoMapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressQueryResponse, Address>().ReverseMap();
            CreateMap<CreateAddressCommandRequest, Address>().ReverseMap();
        }
    }
}
