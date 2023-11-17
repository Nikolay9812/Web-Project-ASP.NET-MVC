using GreenFlix.Services.Movies;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GreenFlix.Data.DataConstants.Movie;

namespace GreenFlix.Models.Movies
{
    public class MovieFormModel
    {
        [Required]
        [StringLength(TitleMaxLenght,MinimumLength = TitleMinLenght)]
        public string Title { get; init; }

        [Range(YearMinValue, YearMaxValue)]
        public int Year { get; init; }

        [Required]
        [StringLength(GenreMaxLenght, MinimumLength = GenreMinLenght)]
        public string Genre { get; init; }

        [Required]
        [StringLength(DirectorsMaxLenght, MinimumLength = DirectorsMinLenght)]
        public string Directors { get; init; }

        [Required]
        [StringLength(WritersMaxLenght, MinimumLength = WritersMinLenght)]
        public string Writers { get; init; }

        [Required]
        [StringLength(StarsMaxLenght, MinimumLength = StarsMinLenght)]
        public string Stars { get; init; }

        [Required]
        [StringLength(int.MaxValue, 
            MinimumLength = DescriptionMinLenght,
            ErrorMessage = "The field Description must be a string with a minimum length of {2}.")]
        public string Description { get; init; }

        [Display(Name = "Image URL")]
        [Required]
        [Url]
        public string ImageUrl { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<MovieCategoryServiceModel> Categories { get; set; }
    }
}
