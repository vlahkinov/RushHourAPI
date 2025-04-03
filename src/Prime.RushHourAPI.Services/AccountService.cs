using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos.AccountDtos;
using System;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository userRepository;

        public AccountService(IAccountRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task DeleteAccount(Guid id)
        {
            await userRepository.DeleteAsync(id);
        }

        public async Task<AccountDto> GetCurrentAccount(Guid id)
        {

            return await userRepository.GetByIdAsync<AccountDto>(id);
        }

        public async Task UpdateAccount(AccountDtoWithId userDto)
        {
            var password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            userDto.Password = password;
            await userRepository.UpdateAsync(userDto);
        }
    }
}
