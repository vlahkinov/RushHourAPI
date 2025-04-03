using Prime.RushHourAPI.Domain.Abstractions.Repositories;
using Prime.RushHourAPI.Domain.Abstractions.Services;
using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.AccountDtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository accountRepository;
        private readonly JWTService jWTService;

        public AuthService(IAccountRepository accountRepository, JWTService jWTService)
        {
            this.accountRepository = accountRepository;
            this.jWTService = jWTService;
        }

        public async Task<JWTDto> Login(string email, string password)
        {
            var users = await accountRepository.GetAsync<AccountDtoWithId>(user => user.Email == email);
            var account = users.First();
            var isVerified = BCrypt.Net.BCrypt.Verify(password, account.Password);

            if (!isVerified)
            {
                throw new ArgumentException();
            }
            else if (account == null || account.IsDeleted)
            {
                throw new KeyNotFoundException();
            }
             
            return await jWTService.GenerateToken(account);
        }

        

        public async Task Register(AccountDto accountDto)
        {
            accountDto.Password = BCrypt.Net.BCrypt.HashPassword(accountDto.Password);
            await accountRepository.CreateAsync(accountDto);
        }

        
    }
}
