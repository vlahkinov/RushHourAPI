using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Data.Entities
{
    public class Provider : BaseEntity
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [Url]
        public string Website { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression("[A-Za-z]")]
        public string Domain { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        [Column(TypeName = "varchar(256)")]
        public ICollection<DayOfWeek> WorkingDays { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Activity> Activities { get; set; } 


    }
}
