using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.CommandHandlers.AddressCommandHandlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest>
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Address
            {
                AddressLine = request.AddressLine,
                District = request.District,
                Province = request.Province,
                CustomerID  = request.CustomerID,
            });
            return Unit.Value;
        }
    }
}
