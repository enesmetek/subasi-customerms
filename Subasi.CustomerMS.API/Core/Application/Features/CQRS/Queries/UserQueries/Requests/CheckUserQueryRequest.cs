using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.UserQueries.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.UserQueries.Requests
{
    public class CheckUserQueryRequest : IRequest<CheckUserQueryResponse>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!; 
    }
}
