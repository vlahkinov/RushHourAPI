using System;

namespace Prime.RushHourAPI.Data.Entities
{
    public class ActivityAppointment : BaseEntity
    {
        public Guid AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }

        public Guid ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        
    }
}
