using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.DTOs.AddressDTOs;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.AddressQueries;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Application.Interfaces;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.AddressQueryHandlers
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQueryRequest, AddressListDTO>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddressListDTO> Handle(GetAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<AddressListDTO>(data);
        }
    }
}
