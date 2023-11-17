using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Services.Movies
{
    public class MovieServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public int Year { get; init; }

        public string Genre { get; init; }

        public string Directors { get; init; }

        public string Writers { get; init; }

        public string Stars { get; init; }

        public string Description { get; init; }

        public string ImageUrl { get; init; }

        public string CategoryName { get; init; }
    }
}
