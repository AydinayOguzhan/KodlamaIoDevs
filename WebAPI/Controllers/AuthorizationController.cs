using Application.Features.Authorizations.Commands.Register;
using Application.Features.Authorizations.Dtos;
using Application.Features.Authorizations.Queries.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            RegisteredDto result = await Mediator.Send(registerCommand);
            return Created("", result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
        {
            LoginDto result = await Mediator.Send(loginQuery);
            return Ok(result);
        }
    }
}
