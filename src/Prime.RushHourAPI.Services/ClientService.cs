using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository repository;

        public ClientService(IClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(ClientDto client)
        {
            await repository.CreateAsync(client);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<PaginatedResult<ClientDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var clients = await repository.GetAllAsync<ClientDto>(pageNumber, pageSize);
            return clients;

        }

        public async Task<ClientDtoWithId> GetAsync(Guid id)
        {
            var client = await repository.GetByIdAsync<ClientDtoWithId>(id);
            return client;
        }

        public async Task UpdateAsync(ClientDtoWithId client)
        {
            await repository.UpdateAsync(client);
        }
    }
}
