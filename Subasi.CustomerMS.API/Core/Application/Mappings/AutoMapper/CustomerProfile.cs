using AutoMapper;
using Subasi.CustomerMS.API.Core.Application.DTOs.CustomerDTOs;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Mappings.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerListDTO, Customer>().ReverseMap();
        }
    }
}
