using Prime.RushHourAPI.Domain.Dtos.AccountDtos;
using System;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Abstractions.Services
{
    public interface IAccountService
    {
        public Task<AccountDto> GetCurrentAccount(Guid id);

        public Task UpdateAccount(AccountDtoWithId accountDto);

        public Task DeleteAccount(Guid id);
    }
}
