using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Data.Entities
{
    public class Account : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        [RegularExpression("[A-Za-z]")]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public Guid RoleId { get; set; }

        public virtual Client Client { get; set; }
        
        public virtual Employee Employee { get; set; }
        
        public bool IsDeleted { get; set; }

    }
}
