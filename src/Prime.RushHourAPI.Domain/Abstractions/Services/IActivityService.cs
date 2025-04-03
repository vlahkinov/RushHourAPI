using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Abstractions.Services
{
    public interface IActivityService
    {
        public Task CreateAsync(ActivityDto activityDto);
        public Task<ActivityDtoWithId> GetAsync(Guid id);

        public Task<PaginatedResult<ActivityDtoWithEmployees>> GetAllAsync(int pageNumber, int pageSize);

        public Task UpdateAsync(ActivityDtoWithId activityDto);

        public Task DeleteAsync(Guid id);
    }
}
