using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos
{
    public class EmployeeDto
    {
        public string Title { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public decimal RatePerHour { get; set; }

        public Guid AccountId { get; set; }

        public Guid ProviderId { get; set; }
        
    }
}
