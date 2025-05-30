﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.RushHourAPI.Domain.Dtos
{
    public class JWTSettingsDto
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Expiration { get; set; }
    }
}
