using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.CommandHandlers.CustomerCommandHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.ID);
            if(deletedEntity != null)
            {
                await _repository.DeleteAsync(deletedEntity);
                return new DeleteCustomerCommandResponse()
                {
                    IsSucceed = true,
                };
            }
            return new DeleteCustomerCommandResponse()
            {
                IsSucceed = false
            };  
        }
    }
}
