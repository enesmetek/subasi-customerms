using AutoMapper;
using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.RefreshTokenQueries.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.RefreshTokenQueries.Responses;
using Subasi.CustomerMS.API.Core.Application.Infrastructure.Tools;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Concrete;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.RefreshTokenQueryHandlers
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQueryRequest, RefreshTokenQueryResponse>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public RefreshTokenQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RefreshTokenQueryResponse> Handle(RefreshTokenQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByFilterAsync(x => x.RefreshToken == request.Token);
            if(user != null)
            {
                var newRefreshToken = JWTGenerator.GenerateRefreshToken();
                user.RefreshToken = newRefreshToken.Token;
                user.TokenCreated = newRefreshToken.Created;
                user.TokenExpires = newRefreshToken.Expires;

                var response = _mapper.Map<RefreshTokenQueryResponse>(newRefreshToken);
                //response.Token = JWTGenerator.GenerateToken().Token;
                return response;
            }
            return new RefreshTokenQueryResponse();
        }
    }
}
