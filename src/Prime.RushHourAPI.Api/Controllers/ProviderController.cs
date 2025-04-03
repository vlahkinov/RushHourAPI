using Microsoft.AspNetCore.Mvc;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Provider;
using System;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService service;

        public ProviderController(IProviderService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderDtoWithId>> Get(Guid id)
        {
            var provider = await service.GetAsync(id);
            if (provider == null) return NotFound();

            return Ok(provider);
        }

        [HttpGet()]
        public async Task<PaginatedResult<ProviderDtoWithOthers>> GetAll([FromQuery(Name = "pageNumber")] int pageNumber,
            [FromQuery(Name = "pageSize")] int pageSize)
        {
            return await service.GetAllAsync(pageNumber, pageSize);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProviderDto provider)
        {
            await service.CreateAsync(provider);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ProviderDtoWithId provider, Guid id)
        {
            provider.Id = id;
            await service.UpdateAsync(provider);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }

    }
}