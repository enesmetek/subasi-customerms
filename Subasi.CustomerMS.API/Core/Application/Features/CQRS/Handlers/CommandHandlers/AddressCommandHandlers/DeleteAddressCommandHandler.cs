using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.CommandHandlers.AddressCommandHandlers
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
    {
        private readonly IAddressRepository _repository;

        public DeleteAddressCommandHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.ID);
            if(deletedEntity != null)
            {
                await _repository.DeleteAsync(deletedEntity);
                return new DeleteAddressCommandResponse()
                {
                    IsSucceed = true
                };
            }
            return new DeleteAddressCommandResponse()
            {
                IsSucceed = false
            };
        }
    }
}
