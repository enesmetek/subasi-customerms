using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Requests
{
    public class DeleteAddressCommandRequest : IRequest<DeleteAddressCommandResponse>
    {
        public DeleteAddressCommandRequest(Guid id)
        {
            ID = id;
        }
        public Guid ID { get; set; } 
    }
}
