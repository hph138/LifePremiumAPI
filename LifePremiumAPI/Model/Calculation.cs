﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePremiumAPI.Model
{
    public class Calculation
    {
        public int Age { get; set; }
        public decimal Amount { get; set; }

        public int RateId { get; set; }
        public decimal Premium { get; set; }
    }
}
