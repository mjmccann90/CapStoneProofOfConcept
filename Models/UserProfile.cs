using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapStoneProofOfConcept.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255, MinimumLength = 5)]
        public string Email { get; set; }

        public string PersonalityType { get; set; }
        //public PersonalityType PersonalityType { get; set; }

    }
}
