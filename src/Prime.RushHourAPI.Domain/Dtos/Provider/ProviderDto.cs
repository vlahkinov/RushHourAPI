using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos.Provider
{
    public class ProviderDto
    {
        
        public string Name { get; set; }
        
        public string Website { get; set; }
        
        public string Domain { get; set; }
        
        public string Phone { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public ICollection<DayOfWeek> WorkingDays { get; set; }

       
    }
}
