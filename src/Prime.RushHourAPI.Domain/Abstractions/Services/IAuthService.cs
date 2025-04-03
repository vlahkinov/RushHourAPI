using Prime.RushHourAPI.Domain.Dtos;
using Prime.RushHourAPI.Domain.Dtos.AccountDtos;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Abstractions.Services
{
    public interface IAuthService
    {
        public Task Register(AccountDto accountDto);
        public Task<JWTDto> Login(string email, string password);
    }
}
