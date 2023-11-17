using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Services.Movies
{
    public class MovieDetailsServiceModel : MovieServiceModel
    {
        public int ProvaiderId { get; init; }

        public string ProvaiderName { get; init; }

        public int CategoryId { get; init; }

        public string UserId { get; init; }
    }
}
