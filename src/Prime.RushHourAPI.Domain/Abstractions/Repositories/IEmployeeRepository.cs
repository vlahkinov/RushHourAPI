using Prime.RushHourAPI.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Abstractions.Repositories
{
    public interface IEmployeeRepository : IBaseRepository
    {
        Task<EmployeeDto>  CreateAsync(EmployeeDto dto);
    }
}
