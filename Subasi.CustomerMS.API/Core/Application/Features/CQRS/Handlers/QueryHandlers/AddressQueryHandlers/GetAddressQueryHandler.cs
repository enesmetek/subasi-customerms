using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.AddressQueryHandlers
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQueryRequest, AddressQueryResponse>
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddressQueryResponse> Handle(GetAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<AddressQueryResponse>(data);
        }
    }
}
