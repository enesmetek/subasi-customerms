using AutoMapper;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Responses;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Mappings.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerQueryResponse, Customer>().ReverseMap();
            CreateMap<CreateCustomerCommandRequest, Customer>().ReverseMap();
        }
    }
}
