using MediatR;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands
{
    public class DeleteCustomerCommandRequest : IRequest
    {
        public DeleteCustomerCommandRequest(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
