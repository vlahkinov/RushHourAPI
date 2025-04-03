using Microsoft.AspNetCore.Mvc;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Activity;
using System;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService service;

        public ActivityController(IActivityService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDtoWithId>> Get(Guid id)
        {
            var activity = await service.GetAsync(id);
            if (activity == null) return NotFound();

            return Ok(activity);
        }

        [HttpGet()]
        public async Task<PaginatedResult<ActivityDtoWithEmployees>> GetAll([FromQuery(Name = "pageNumber")] int pageNumber,
            [FromQuery(Name = "pageSize")] int pageSize)
        {
            return await service.GetAllAsync(pageNumber, pageSize);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ActivityDto activity)
        {
            await service.CreateAsync(activity);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ActivityDtoWithId activity, Guid id)
        {
            activity.Id = id;
            await service.UpdateAsync(activity);
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
