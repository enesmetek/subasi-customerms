using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.DTOs.AddressDTOs;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.AddressQueryHandlers
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQueryRequest, List<AddressListDTO>>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAllAddressesQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AddressListDTO>> Handle(GetAllAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<AddressListDTO>>(data);
        }
    }
}
