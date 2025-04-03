using AutoMapper;
using Prime.RushHourAPI.Data.Entities;
using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Data.Repositories
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(RushHourAPIDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
