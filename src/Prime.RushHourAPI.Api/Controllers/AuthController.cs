using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos.AccountDtos;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Api.Controllers
{

    
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;



        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> Login(AccountLoginDto accountDto)
        {
            var token = await authService.Login(accountDto.Email, accountDto.Password);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/register")]
        public async Task<IActionResult> Register(AccountDto accountDto)
        {
            await authService.Register(accountDto);
            return Ok();
        }

    }
}
