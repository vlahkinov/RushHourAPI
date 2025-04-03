using Prime.RushHourAPI.Domain.Dtos.AccountDtos;
using Prime.RushHourAPI.Domain.Dtos.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos.Employee
{
    public class EmployeeDtoWithOthers
    {
        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public decimal RatePerHour { get; set; }

        public ProviderDto Provider { get; set; }

        public AccountDto Account { get; set; }
    }
}
