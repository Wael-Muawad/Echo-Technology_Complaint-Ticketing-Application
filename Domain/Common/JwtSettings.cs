﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
