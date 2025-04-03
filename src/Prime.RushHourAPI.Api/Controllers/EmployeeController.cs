using Microsoft.AspNetCore.Mvc;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Employee;
using System;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDtoWithId>> Get(Guid id)
        {
            var employee = await service.GetAsync(id);
            if (employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpGet()]
        public async Task<PaginatedResult<EmployeeDtoWithOthers>> GetAll([FromQuery(Name = "pageNumber")] int pageNumber,
            [FromQuery(Name = "pageSize")] int pageSize)
        {
            return await service.GetAllAsync(pageNumber, pageSize);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDto employee)
        {
            await service.CreateAsync(employee);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(EmployeeDtoWithId employee, Guid id)
        {
            employee.Id = id;
            await service.UpdateAsync(employee);
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
