using Prime.RushHourAPI.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Abstractions.Repositories
{
    public interface IAccountRepository : IBaseRepository
    {
        Task<IEnumerable<TDto>> GetAsync<TDto>(
            Expression<Func<TDto, bool>> filter);
    }
}
