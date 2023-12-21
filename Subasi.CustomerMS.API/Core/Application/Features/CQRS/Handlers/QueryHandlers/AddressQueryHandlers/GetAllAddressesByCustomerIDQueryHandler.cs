using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.DTOs.AddressDTOs;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries;
using Subasi.CustomerMS.API.Core.Application.Interfaces;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.AddressQueryHandlers
{
    public class GetAllAddressesByCustomerIDQueryHandler : IRequestHandler<GetAllAddressesByCustomerIDQueryRequest, List<AddressListDTO>>
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAddressesByCustomerIDQueryHandler(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AddressListDTO>> Handle(GetAllAddressesByCustomerIDQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAddressesByCustomerID(request.ID);
            return _mapper.Map<List<AddressListDTO>>(data);
        }
    }
}
