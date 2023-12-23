using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Responses;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Requests
{
    public class DeleteCustomerCommandRequest : IRequest<DeleteCustomerCommandResponse>
    {
        public DeleteCustomerCommandRequest(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
