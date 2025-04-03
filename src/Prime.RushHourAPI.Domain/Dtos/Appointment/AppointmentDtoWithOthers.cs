using Prime.RushHourAPI.Domain.Dtos.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos.Appointment
{
    public class AppointmentDtoWithOthers
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<ActivityDto> Activities { get; set; }
        public ClientDto Client { get; set; }
        public EmployeeDto Employee { get; set; }
        public decimal Price { get; set; }
    }
}
