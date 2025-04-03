using Microsoft.IdentityModel.Tokens;
using Prime.RushHourAPI.Domain.Abstractions.Repositories;
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
    public class JWTService
    {
        private readonly JWTSettingsDto settingsDto;
        private readonly IRoleRepository roleRepository;

        public JWTService(JWTSettingsDto settingsDto, IRoleRepository roleRepository)
        {
            this.settingsDto = settingsDto;
            this.roleRepository = roleRepository;
        }
        public  async Task<JWTDto> GenerateToken(AccountDtoWithId account)
        {
            RoleDto roleDto = await roleRepository.GetByIdAsync<RoleDto>(account.RoleId);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(settingsDto.Key);
            var token = new JwtSecurityToken(
                issuer: settingsDto.Issuer,
                audience: settingsDto.Audience,
                expires: DateTime.UtcNow.AddHours(int.Parse(settingsDto.Expiration)),
                claims: GetClaims(account, roleDto.Name),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                );
            return new JWTDto()
            {
                Token = tokenHandler.WriteToken(token),
            };

            
                
            
        }
        public Guid? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settingsDto.Key);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = settingsDto.Issuer,
                    ValidAudience = settingsDto.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                    
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                
                return userId;
            }
            catch
            {
                
                return null;
            }
        }
        private static List<Claim> GetClaims(AccountDtoWithId user, string role)
        {
            return new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email.ToString()),
                new Claim(ClaimTypes.Role, role)
            };
        }

    }
}
