using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.DTOs.CustomerDTOs;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.CustomerQueryHandlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, List<CustomerListDTO>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CustomerListDTO>> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllCustomersWithAddresses();
            return _mapper.Map<List<CustomerListDTO>>(data);
        }
    }
}
