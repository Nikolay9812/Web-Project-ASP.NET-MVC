using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Models.Home
{
    public class MovieIndexViewModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        //[Range(YearMinValue, YearMaxValue)]
        public int Year { get; init; }

        [Required]
        //[StringLength(GenreMaxLenght, MinimumLength = GenreMinLenght)]
        public string Genre { get; init; }

        [Required]
        //[StringLength(DirectorsMaxLenght, MinimumLength = DirectorsMinLenght)]
        public string Directors { get; init; }

        [Required]
        //[StringLength(WritersMaxLenght, MinimumLength = WritersMinLenght)]
        public string Writers { get; init; }

        [Required]
        //[StringLength(StarsMaxLenght, MinimumLength = StarsMinLenght)]
        public string Stars { get; init; }

        [Required]
        //[StringLength(int.MaxValue,
        //MinimumLength = DescriptionMinLenght,
        //ErrorMessage = "The field Description must be a string with a minimum length of {2}.")]
        public string Description { get; init; }

        //[Display(Name = "Image URL")]
        //[Required]
        //[Url]
        public string ImageUrl { get; init; }
    }
}
