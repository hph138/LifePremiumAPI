using System;
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
        [Range( 0,110,ErrorMessage ="Invalid age") ]
        public int Age { get; set; }

        [Required]
        public DateTime? Dob { get; set; }

        [Required]
        public double Amount { get; set; }
        public string RateId { get; set; }
    }
}
