using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Subasi.CustomerMS.API.Core.Application.Interface;
using Subasi.CustomerMS.API.Core.Domain.Concrete;
using Subasi.CustomerMS.API.Infrastructure;
using Subasi.CustomerMS.API.Infrastructure.Enums;
using Subasi.CustomerMS.API.Infrastructure.Services;
using Subasi.CustomerMS.API.Infrastructure.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Subasi.CustomerMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static AppUser user = new();
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AuthController(IAppUserService appUserService, IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository, IMapper mapper)
        {
            _appUserService = appUserService;
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
            _mapper = mapper;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = _appUserService.GetMyName();
            return Ok(userName);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(UserDTO request)
        {
            var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username);
            if(user==null)
            {
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var newUser = new AppUser
                {
                    Username = request.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    AppRoleID = (int)RoleType.Member,
                    AppRoleName = "Member"
                };
                
                await _appUserRepository.CreateAsync(newUser);

                return Ok(newUser.Username);
            }
            return BadRequest("Username is not valid.");
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username);
            if (user != null && VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                string token = CreateToken(user);

                var refreshToken = GenerateRefreshToken();
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = refreshToken.Expires
                };
                Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
                Response.Cookies.Append("username", user.Username, cookieOptions);

                user.RefreshToken = refreshToken.Token;
                user.TokenCreated = refreshToken.Created;
                user.TokenExpires = refreshToken.Expires;

                await _appUserRepository.UpdateAsync(user);
                return Ok(token);
            }
            return BadRequest("Username or password is wrong.");
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var username = Request.Cookies["username"];
            var user = await _appUserRepository.GetByFilterAsync(x => x.Username == username);
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }
            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
            await _appUserRepository.UpdateAsync(user);
            return Ok(token);
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private string CreateToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.AppRoleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTDefaults.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                issuer: JWTDefaults.ValidIssuer,
                audience: JWTDefaults.ValidAudience,
                expires: DateTime.Now.AddDays(JWTDefaults.Expire),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
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
