using MediatR;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.UserQueries.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.UserQueries.Responses;
using Subasi.CustomerMS.API.Core.Application.Infrastructure.Tools;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Concrete;
using System.Security.Cryptography;

namespace Subasi.CustomerMS.API.Core.Application.Features.CQRS.Handlers.QueryHandlers.UserQueryHandlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserQueryResponse>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public CheckUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<CheckUserQueryResponse> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CheckUserQueryResponse();

            var refreshToken = JWTGenerator.GenerateRefreshToken();

            var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username);
            if (user != null && VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.ID = user.ID;
                response.Username = user.Username;
                response.Role = (await _appRoleRepository.GetByFilterAsync(x => x.ID == user.AppRoleID))?.Definition;
                response.IsExist = true;
                user.RefreshToken = refreshToken.Token;
                user.TokenCreated = refreshToken.Created;
                user.TokenExpires = refreshToken.Expires;
                await _appUserRepository.SaveChangesAsync();
            }
            else
            {
                response.IsExist = false;
            }
            return response;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
