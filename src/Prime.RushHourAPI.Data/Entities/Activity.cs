using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Data.Entities
{
    public class Activity : BaseEntity 
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        
        [RegularExpression(@"^(?!0*[.,]0*$|[.,]0*$|0*$)\d+[,.]?\d{0,2}$")]
        
        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public virtual ICollection<ActivityAppointment> ActivityAppointments { get; set; }

        public virtual Provider Provider { get; set; }

        public Guid ProviderId { get; set; }

        public virtual ICollection<ActivityEmployee> ActivityEmployees { get; set;}
    }
}
