using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Data.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [RegularExpression("^[a-zA-Z0-9_]*$")]
        public string Title { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^(?:[1-9]\d*(\.\d+)?|0?\.\d+|0)$")]
        public decimal RatePerHour { get; set; }
        public Guid ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public Guid AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        
        public virtual ICollection<ActivityEmployee> ActivityEmployees { get; set; }

    }
}
