using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.CommandHandlers.CustomerCommandHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Customer>(request));
            return new CreateCustomerCommandResponse();
        }
    }
}
