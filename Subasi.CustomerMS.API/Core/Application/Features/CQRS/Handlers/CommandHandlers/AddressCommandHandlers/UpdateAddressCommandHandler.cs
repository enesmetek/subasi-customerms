using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.CommandHandlers.AddressCommandHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {
        private readonly IAddressRepository _repository;

        public UpdateAddressCommandHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedAddress = await _repository.GetByIdAsync(request.ID);
            if (updatedAddress != null)
            {
                updatedAddress.AddressLine = request.AddressLine;
                updatedAddress.District = request.District;
                updatedAddress.Province = request.Province;
                updatedAddress.CustomerID = request.CustomerID;
                await _repository.UpdateAsync(updatedAddress);
                return new UpdateAddressCommandResponse()
                {
                    IsSucceed = true,
                };
            }
            return new UpdateAddressCommandResponse()
            {
                IsSucceed = false
            };
        }
    }
}
