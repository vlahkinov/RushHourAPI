using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prime.RushHourAPI.Data.Entities;
using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(RushHourAPIDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<TDto>> GetAsync<TDto>(Expression<Func<TDto, bool>> filter)
        {
            var query = Items.AsQueryable();

            if (filter != null)
                query = query.Where(Mapper.Map<Expression<Func<Account, bool>>>(filter));
            return await Mapper.ProjectTo<TDto>(query).ToListAsync();
        }

        public override async Task DeleteAsync(Guid id)
        {
            var user = await Items.FirstOrDefaultAsync(x => x.Id == id);

            user.IsDeleted = true;

            Items.Update(user);

            await DbContext.SaveChangesAsync();
        }

        
    }
}
