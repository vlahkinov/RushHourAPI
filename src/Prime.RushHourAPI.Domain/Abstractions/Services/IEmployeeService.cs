using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Abstractions.Services
{
    public interface IEmployeeService
    {
        public Task CreateAsync(EmployeeDto employeeDto);
        public Task<EmployeeDtoWithId> GetAsync(Guid id);

        public Task<PaginatedResult<EmployeeDtoWithOthers>> GetAllAsync(int pageNumber, int pageSize);

        public Task UpdateAsync(EmployeeDtoWithId employee);

        public Task DeleteAsync(Guid id);
    }
}
