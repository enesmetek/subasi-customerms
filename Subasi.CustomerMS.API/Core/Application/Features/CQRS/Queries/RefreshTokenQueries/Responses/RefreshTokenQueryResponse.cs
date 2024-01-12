using Subasi.CustomerMS.API.Core.Application.DTOs;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.RefreshTokenQueries.Responses
{
    public class RefreshTokenQueryResponse
    {
        public string? Token { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
