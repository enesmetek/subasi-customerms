using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.CustomerQueryHandlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, List<CustomerQueryResponse>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CustomerQueryResponse>> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllCustomersWithAddresses();
            return _mapper.Map<List<CustomerQueryResponse>>(data);
        }
    }
}
