using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Data.Entities
{
    public class Appointment : BaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public virtual ICollection<ActivityAppointment> ActivityAppointments { get; set; }

        public virtual Client Client { get; set; }

        public Guid ClientId { get; set; }  
        public virtual Employee Employee { get; set; }

        public Guid EmployeeId { get; set; }

        [RegularExpression(@"^(?!0*[.,]0*$|[.,]0*$|0*$)\d+[,.]?\d{0,2}$")]

        public decimal Price { get; set; }
        
    }
}
