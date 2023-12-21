using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.CommandHandlers.CustomerCommandHandlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest>
    {
        private readonly IRepository<Customer> _repository;

        public UpdateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedCustomer = await _repository.GetByIdAsync(request.ID);
            if (updatedCustomer != null)
            {
                updatedCustomer.FirstName = request.FirstName;
                updatedCustomer.LastName = request.LastName;
                updatedCustomer.Email = request.Email;
                updatedCustomer.PhoneNumber = request.PhoneNumber;
                await _repository.UpdateAsync(updatedCustomer);
            }
            return Unit.Value;
        }
    }
}
