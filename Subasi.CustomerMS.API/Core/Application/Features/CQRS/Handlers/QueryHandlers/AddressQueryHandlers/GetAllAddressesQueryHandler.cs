using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries.Responses;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.AddressQueryHandlers
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQueryRequest, List<AddressQueryResponse>>
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAddressesQueryHandler(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AddressQueryResponse>> Handle(GetAllAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<AddressQueryResponse>>(data);
        }
    }
}
