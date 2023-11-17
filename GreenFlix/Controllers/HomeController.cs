using GreenFlix.Data;
using GreenFlix.Models;
using GreenFlix.Models.Home;
using GreenFlix.Models.Movies;
using GreenFlix.Services.Statistics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;
        private readonly GreenFlixDbContext data;

        public HomeController(
            IStatisticsService statistics,
            GreenFlixDbContext data)
        {
            this.statistics = statistics;
            this.data = data;
        }

        public IActionResult Index()
        {
            var movies= this.data
                .Movies
                .OrderByDescending(m => m.Id)
                .Select(m => new MovieIndexViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    Genre = m.Genre,
                    Directors = m.Directors,
                    Writers = m.Writers,
                    Stars = m.Stars,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl
                })
                .Take(3)
                .ToList();

            var totalStatistics = this.statistics.Total();

            return View(new IndexViewModel
            {
                TotalMovies = totalStatistics.TotalMovies,
                TotalUsers = totalStatistics.TotalUsers,
                Movies = movies
            }) ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
