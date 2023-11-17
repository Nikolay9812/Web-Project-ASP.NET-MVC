using GreenFlix.Services.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Models.Movies
{
    public class AllMoviesQueryModel
    {
        public const int MoviesPerPage = 3;

        public string Title { get; init;}

        [Display(Name = "Search")]
        public string SearchTerm { get; init;}

        public MovieSorting Sorting { get; init;}

        public int CurentPage { get; init; } = 1;

        public int TotalMovies { get; set; }

        public IEnumerable<string> Titles { get; set;}

        public IEnumerable<MovieServiceModel> Movies { get; set;}

    }
}
