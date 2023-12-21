using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.CommandHandlers.AddressCommandHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest>
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedAddress = await _repository.GetByIdAsync(request.ID);
            if (updatedAddress != null)
            {
                updatedAddress.AddressLine = request.AddressLine;
                updatedAddress.District = request.District;
                updatedAddress.Province = request.Province;
                updatedAddress.CustomerID = request.CustomerID;
                await _repository.UpdateAsync(updatedAddress);
            }
            return Unit.Value;
        }
    }
}
