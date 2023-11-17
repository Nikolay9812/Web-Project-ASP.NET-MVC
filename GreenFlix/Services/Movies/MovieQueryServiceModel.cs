using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Services.Movies
{
    public class MovieQueryServiceModel
    {
        public int CurentPage { get; init; }

        public int MoviesPerPage { get; init; }

        public int TotalMovies { get; init; }

        public IEnumerable<MovieServiceModel> Movies { get; init; }
    }
}
