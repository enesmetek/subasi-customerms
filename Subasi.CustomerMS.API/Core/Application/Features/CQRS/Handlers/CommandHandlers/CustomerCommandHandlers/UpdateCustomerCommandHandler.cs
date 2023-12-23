using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.CommandHandlers.CustomerCommandHandlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _repository;

        public UpdateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedCustomer = await _repository.GetByIdAsync(request.ID);
            if (updatedCustomer != null)
            {
                updatedCustomer.FirstName = request.FirstName;
                updatedCustomer.LastName = request.LastName;
                updatedCustomer.Email = request.Email;
                updatedCustomer.PhoneNumber = request.PhoneNumber;
                await _repository.UpdateAsync(updatedCustomer);
                return new UpdateCustomerCommandResponse()
                {
                    IsSucceed = true,
                };
            }
            return new UpdateCustomerCommandResponse()
            {
                IsSucceed = false
            };
        }
    }
}
