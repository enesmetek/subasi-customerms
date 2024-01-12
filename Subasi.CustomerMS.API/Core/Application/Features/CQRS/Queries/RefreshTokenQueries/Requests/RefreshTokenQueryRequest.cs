using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.RefreshTokenQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.RefreshTokenQueries.Requests
{
    public class RefreshTokenQueryRequest : IRequest<RefreshTokenQueryResponse>
    {
        public string Token { get; set; } = string.Empty;
    }
}
