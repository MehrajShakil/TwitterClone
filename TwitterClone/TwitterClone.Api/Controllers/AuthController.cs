using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{

    // api/users
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(
            IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var authResponse = _authService.Login(loginDto);

            if(authResponse is null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }

    }
}
