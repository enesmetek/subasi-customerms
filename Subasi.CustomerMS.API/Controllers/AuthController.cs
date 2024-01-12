using MediatR;
using Microsoft.AspNetCore.Mvc;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.UserCommands.Requests;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Queries.UserQueries.Requests;
using Subasi.CustomerMS.API.Core.Application.Infrastructure.Tools;

namespace Subasi.CustomerMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request.Username);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var user = await _mediator.Send(request);
            if (user.IsExist)
            {
                var refreshToken = JWTGenerator.GenerateRefreshToken();

                return Created("", JWTGenerator.GenerateToken(user));
            }
            return BadRequest("Username or password is wrong.");
        }

        //[HttpPost("RefreshToken")]
        //public async Task<IActionResult> RefreshToken(CheckUserQueryRequest request)
        //{
        //    var refreshToken = Request.Cookies["refreshToken"];
        //    var user = await _mediator.Send(request);
        //    if (user.IsExist)
        //    {
        //        return Created("", JWTGenerator.GenerateToken(user));
        //    }
        //    return
        //}

        //private void SetRefreshToken(RefreshToken newRefreshToken)
        //{
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = newRefreshToken.Expires
        //    };
        //    Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

        //    user.RefreshToken = newRefreshToken.Token;
        //    user.TokenCreated = newRefreshToken.Created;
        //    user.TokenExpires = newRefreshToken.Expires;
        //}
    }
}
