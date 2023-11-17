using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GreenFlix.Data.DataConstants.Provaider;

namespace GreenFlix.Data.Models
{
    public class Provaider
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<Movie> Movies { get; init; } = new List<Movie>();
    }
}
