using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Abstractions.Services
{
    public interface IClientService 
    {
        public Task CreateAsync(ClientDto clientDto);
        public Task<ClientDtoWithId> GetAsync(Guid id);

        public Task<PaginatedResult<ClientDto>> GetAllAsync(int pageNumber, int pageSize);

        public Task UpdateAsync(ClientDtoWithId clientDto);

        public Task DeleteAsync(Guid id);
    }
}
