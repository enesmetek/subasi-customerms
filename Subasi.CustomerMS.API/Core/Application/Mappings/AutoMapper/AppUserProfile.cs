using AutoMapper;
using Subasi.CustomerMS.API.Core.Domain.Concrete;
using Subasi.CustomerMS.API.Infrastructure;

namespace Subasi.CustomerMS.API.Core.Application.Mappings.AutoMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, UserDTO>().ReverseMap();
        }
    }
}
