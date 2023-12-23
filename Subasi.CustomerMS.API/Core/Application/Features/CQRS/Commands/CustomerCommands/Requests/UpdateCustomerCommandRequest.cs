using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Requests
{
    public class UpdateCustomerCommandRequest : IRequest<UpdateCustomerCommandResponse>
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
