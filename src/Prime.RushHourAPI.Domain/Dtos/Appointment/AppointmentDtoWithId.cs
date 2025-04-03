using Prime.RushHourAPI.Domain.Dtos.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos.Appointment
{
    public class AppointmentDtoWithId
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<ActivityDto> Activities { get; set; }
        public Guid ClientId { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Price { get; set; }
    }
}
