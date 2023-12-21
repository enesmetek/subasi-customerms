using AutoMapper;
using Subasi.CustomerMS.API.Core.Application.DTOs.AddressDTOs;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Mappings.AutoMapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressListDTO, Address>().ReverseMap();
        }
    }
}
