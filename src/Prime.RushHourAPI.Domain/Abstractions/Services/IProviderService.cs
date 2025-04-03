using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Abstractions.Services
{
    public interface IProviderService
    {
        public Task CreateAsync(ProviderDto providertDto);
        public Task<ProviderDtoWithId> GetAsync(Guid id);

        public Task<PaginatedResult<ProviderDtoWithOthers>> GetAllAsync(int pageNumber, int pageSize);

        public Task UpdateAsync(ProviderDtoWithId providertDto);

        public Task DeleteAsync(Guid id);
    }
}
