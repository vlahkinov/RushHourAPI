﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos.Activity
{
    public class ActivityDtoWithId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid ProviderId { get; set; }
    }
}
