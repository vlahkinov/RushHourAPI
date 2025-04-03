using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos
{
    public class ClientDto
    {
        public string Phone { get; set; }
        
        public string Address { get; set; }

        public Guid AccountId { get; set; }
    }
}
