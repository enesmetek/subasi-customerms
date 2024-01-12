using AutoMapper;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.RefreshTokenQueries.Responses;
using Subasi.CustomerMS.API.Core.Application.Infrastructure.Tools;

namespace Subasi.CustomerMS.API.Core.Application.Mappings.AutoMapper
{
    public class RefreshTokenProfile : Profile
    {
        public RefreshTokenProfile()
        {
            CreateMap<RefreshToken, RefreshTokenQueryResponse>().ReverseMap();
        }
    }
}
