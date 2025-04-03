using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Data.Entities
{
    public class ActivityEmployee : BaseEntity
    {
        public Guid ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public Guid EmployeeId  { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
