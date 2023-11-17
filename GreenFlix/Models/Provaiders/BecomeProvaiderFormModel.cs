using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static GreenFlix.Data.DataConstants.Provaider;

namespace GreenFlix.Models.Provaiders
{
    public class BecomeProvaiderFormModel
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght)]
        public string Name { get; init; }

        [Required]
        [StringLength(PhoneNumberMaxLenght, MinimumLength = PhoneNumberMinLenght)]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; init; }
    }
}
