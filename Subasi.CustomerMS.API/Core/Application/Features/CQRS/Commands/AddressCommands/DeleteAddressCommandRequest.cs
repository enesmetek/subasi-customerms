using MediatR;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands
{
    public class DeleteAddressCommandRequest : IRequest
    {
        public DeleteAddressCommandRequest(int id)
        {
            ID = id;
        }
        public int ID { get; set; } 
    }
}
