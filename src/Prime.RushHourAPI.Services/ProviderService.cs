using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository repository;

        public ProviderService(IProviderRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(ProviderDto providerDto)
        {
            await repository.CreateAsync(providerDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<PaginatedResult<ProviderDtoWithOthers>> GetAllAsync(int pageNumber, int pageSize)
        {
            var proviers = await repository.GetAllAsync<ProviderDtoWithOthers>(pageNumber, pageSize);
            return proviers;

        }

        public async Task<ProviderDtoWithId> GetAsync(Guid id)
        {
            var user = await repository.GetByIdAsync<ProviderDtoWithId>(id);
            return user;
        }

        public async Task UpdateAsync(ProviderDtoWithId accountDto)
        {
            await repository.UpdateAsync(accountDto);
        }
    }
}
