using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Requests
{
    public class DeleteCustomerCommandRequest : IRequest<DeleteCustomerCommandResponse>
    {
        public DeleteCustomerCommandRequest(Guid id)
        {
            ID = id;
        }

        public Guid ID { get; set; }
    }
}
