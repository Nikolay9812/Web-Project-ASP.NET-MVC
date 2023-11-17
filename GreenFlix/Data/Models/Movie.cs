using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static GreenFlix.Data.DataConstants.Movie;

namespace GreenFlix.Data.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(GenreMaxLenght)]
        public string Genre { get; set; }

        [Required]
        [MaxLength(DirectorsMaxLenght)]
        public string Directors { get; set; }

        [Required]
        [MaxLength(WritersMaxLenght)]
        public string Writers { get; set; }

        [Required]
        [MaxLength(StarsMaxLenght)]
        public string Stars { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public int ProvaiderId { get; init; }

        public Provaider Provaider { get; init; }
    }
}
