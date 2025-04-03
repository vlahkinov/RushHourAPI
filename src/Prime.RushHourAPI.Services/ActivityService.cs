using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository repository;

        public ActivityService(IActivityRepository repository)
        {
            this.repository = repository;
        }
        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id); 
        }
        public async Task CreateAsync(ActivityDto activityDto)
        {
            await repository.CreateAsync(activityDto);
        }
        public async Task<PaginatedResult<ActivityDtoWithEmployees>> GetAllAsync(int pageNumber, int pageSize)
        {
            var activity = await repository.GetAllAsync<ActivityDtoWithEmployees>(pageNumber, pageSize);
            return activity;

        }
        public async Task<ActivityDtoWithId> GetAsync(Guid id)
        {
            var activity = await repository.GetByIdAsync<ActivityDtoWithId>(id);
            return activity;
        }

        public async Task UpdateAsync(ActivityDtoWithId activity)
        {
            await repository.UpdateAsync(activity);
        }
    }
}
