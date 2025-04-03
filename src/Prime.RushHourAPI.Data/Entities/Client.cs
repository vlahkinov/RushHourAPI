using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Data.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [MinLength(3)]
        public string Address { get; set; }
        
        public virtual Account Account { get; set; }
        
        public Guid AccountId   { get; set; }

    }
}
