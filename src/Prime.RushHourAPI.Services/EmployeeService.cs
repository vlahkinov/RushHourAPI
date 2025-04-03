using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;
        

        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
            
        }

        public async Task CreateAsync(EmployeeDto employee)
        {
            
            await repository.CreateAsync(employee);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<PaginatedResult<EmployeeDtoWithOthers>> GetAllAsync(int pageNumber, int pageSize)
        {
            var employees = await repository.GetAllAsync<EmployeeDtoWithOthers>(pageNumber, pageSize);
            return employees;

        }

        public async Task<EmployeeDtoWithId> GetAsync(Guid id)
        {
            var employee = await repository.GetByIdAsync<EmployeeDtoWithId>(id);
            return employee;
        }

        public async Task UpdateAsync(EmployeeDtoWithId employee)
        {
            await repository.UpdateAsync(employee);
        }
    }
}
