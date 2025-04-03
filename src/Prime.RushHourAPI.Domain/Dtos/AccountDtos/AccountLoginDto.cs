using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos.AccountDtos
{
    public class AccountLoginDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
