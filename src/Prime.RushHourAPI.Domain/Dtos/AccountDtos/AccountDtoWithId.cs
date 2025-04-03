using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos.AccountDtos
{
    public class AccountDtoWithId
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public Guid RoleId    { get; set; }
        public bool IsDeleted { get; set; }
    }
}
