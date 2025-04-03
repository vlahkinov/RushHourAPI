using AutoMapper;
using Prime.RushHourAPI.Data.Entities;
using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Dtos;
using System;
using System.Threading.Tasks;


namespace Prime.RushHourAPI.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly IAccountRepository accountRepository;

        public EmployeeRepository(RushHourAPIDbContext dbContext, IMapper mapper, IAccountRepository accountRepository) : base(dbContext, mapper)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<EmployeeDto> CreateAsync(EmployeeDto dto)
        {
            var account = await accountRepository.GetByIdAsync<Account>(dto.AccountId);
            if (account.Client != null || account.Employee != null)
            {
                throw new InvalidOperationException();
            }
            return await base.CreateAsync(dto);
        }
    }
}
