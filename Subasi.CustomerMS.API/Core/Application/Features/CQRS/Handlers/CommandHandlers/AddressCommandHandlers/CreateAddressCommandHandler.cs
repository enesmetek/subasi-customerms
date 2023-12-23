using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.CommandHandlers.AddressCommandHandlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Address>(request));
            return new CreateAddressCommandResponse();
        }
    }
}
