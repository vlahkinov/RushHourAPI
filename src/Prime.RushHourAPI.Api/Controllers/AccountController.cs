using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos.AccountDtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        [HttpDelete]

        public async Task<IActionResult> Delete()
        {
            var newId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
            await service.DeleteAccount(newId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(AccountDtoWithId userDto)
        {
            var id = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
            userDto.Id = id;

            await service.UpdateAccount(userDto);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var id = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
            
            var user = await service.GetCurrentAccount(id);
            
            return Ok(user);

        }
    }
}
