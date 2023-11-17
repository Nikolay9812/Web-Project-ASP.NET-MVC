using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Services.Statistics
{
    public class StatisticsServiceModel
    {
        public int TotalMovies { get; init; }

        public int TotalUsers { get; init; }

        public int TotalRents { get; init; }
    }
}
