using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.UserCommands.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.UserCommands.Requests
{
    public class RegisterUserCommandRequest : IRequest<RegisterUserCommandResponse>
    {
        public string? Username { get; set; }
        public string Password { get; set; } = string.Empty;
    }   
}
