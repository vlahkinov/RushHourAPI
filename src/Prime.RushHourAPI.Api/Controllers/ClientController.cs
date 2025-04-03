using Microsoft.AspNetCore.Mvc;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Client;
using System;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDtoWithId>> Get(Guid id)
        {
            var client = await service.GetAsync(id);
            if (client == null) return NotFound();

            return Ok(client);
        }

        [HttpGet()]
        public async Task<PaginatedResult<ClientDto>> GetAll([FromQuery(Name = "pageNumber")] int pageNumber,
            [FromQuery(Name = "pageSize")] int pageSize)
        {
            return await service.GetAllAsync(pageNumber, pageSize);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientDto client)
        {
            await service.CreateAsync(client);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ClientDtoWithId client, Guid id)
        {
            client.Id = id;
            await service.UpdateAsync(client);
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
