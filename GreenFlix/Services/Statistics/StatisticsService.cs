using GreenFlix.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly GreenFlixDbContext data;

        public StatisticsService(GreenFlixDbContext data)
            => this.data = data;

        public StatisticsServiceModel Total()
        {
            var totalMovies = this.data.Movies.Count();
            var totalUsers = this.data.Users.Count();

            return new StatisticsServiceModel
            {
                TotalMovies=totalMovies,
                TotalUsers= totalUsers
            };
        }
    }
}
