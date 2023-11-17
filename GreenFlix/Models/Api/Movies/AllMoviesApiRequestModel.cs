using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Models.Api.Movies
{
    public class AllMoviesApiRequestModel
    {
        public string Title { get; init; }

        public string SearchTerm { get; init; }

        public MovieSorting Sorting { get; init; }

        public int CurentPage { get; init; } = 1;

        public int MoviesPerPage { get; init; } = 10;
    }
}
