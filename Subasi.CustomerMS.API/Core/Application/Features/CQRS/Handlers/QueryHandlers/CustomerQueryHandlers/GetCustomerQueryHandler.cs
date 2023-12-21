using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.DTOs.CustomerDTOs;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.CustomerQueryHandlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQueryRequest, CustomerListDTO>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerListDTO> Handle(GetCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetCustomerWithAddress(request.ID);
            return _mapper.Map<CustomerListDTO>(data);
        }
    }
}
