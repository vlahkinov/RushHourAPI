using Microsoft.AspNetCore.Mvc;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Appointment;
using System;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService service;

        public AppointmentController(IAppointmentService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDtoWithId>> Get(Guid id)
        {
            var appointment = await service.GetAsync(id);
            if (appointment == null) return NotFound();

            return Ok(appointment);
        }

        [HttpGet()]
        public async Task<PaginatedResult<AppointmentDtoWithOthers>> GetAll([FromQuery(Name = "pageNumber")] int pageNumber,
            [FromQuery(Name = "pageSize")] int pageSize)
        {
            return await service.GetAllAsync(pageNumber, pageSize);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AppointmentDto appointment)
        {
            await service.CreateAsync(appointment);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(AppointmentDtoWithId appointment, Guid id)
        {
            appointment.Id = id;
            await service.UpdateAsync(appointment);
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
