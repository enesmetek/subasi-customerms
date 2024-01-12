using Microsoft.IdentityModel.Tokens;
using Subasi.CustomerMS.API.Core.Application.DTOs;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.UserQueries.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;



namespace Subasi.CustomerMS.API.Core.Application.Infrastructure.Tools
{
    public class JWTGenerator
    {
        public static TokenResponseDTO GenerateToken(CheckUserQueryResponse user)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(user.Role))
                claims.Add(new Claim(ClaimTypes.Role, user.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));

            if (!string.IsNullOrEmpty(user.Username))
                claims.Add(new Claim("Username", user.Username));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTDefaults.Key));

            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JWTDefaults.Expire);

            JwtSecurityToken jwtSecurityToken = new(issuer: JWTDefaults.ValidIssuer, audience: JWTDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new();

            return new TokenResponseDTO(handler.WriteToken(jwtSecurityToken), expireDate);
        }

        public static RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
            return refreshToken;
        }
    }
}
