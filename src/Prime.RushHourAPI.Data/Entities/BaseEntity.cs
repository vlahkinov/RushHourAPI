using System;
using System.ComponentModel.DataAnnotations;

namespace Prime.RushHourAPI.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }


    }
}
