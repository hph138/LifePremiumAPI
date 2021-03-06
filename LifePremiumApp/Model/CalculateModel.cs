﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifePremiumApp.Model
{
    public class CalculateModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Range( 1,110,ErrorMessage ="Invalid age") ]
        public int Age { get; set; }

        [Required]
        public DateTime? Dob { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Sum insured must be greater than {1}")]
        public decimal Amount { get; set; }
        public int RateId { get; set; }

        public decimal Premium { get; set; }
    }
}
