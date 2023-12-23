using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.CustomerQueries.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.CustomerQueryHandlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQueryRequest, CustomerQueryResponse>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerQueryResponse> Handle(GetCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetCustomerWithAddress(request.ID);
            return _mapper.Map<CustomerQueryResponse>(data);
        }
    }
}
