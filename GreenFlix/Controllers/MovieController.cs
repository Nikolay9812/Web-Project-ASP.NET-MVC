namespace GreenFlix.Controllers
{
    using GreenFlix.Models.Movies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using GreenFlix.Infrastructure;
    using GreenFlix.Services.Movies;
    using GreenFlix.Services.Provaiders;

    public class MovieController : Controller
    {
        private readonly IMovieService movies;
        private readonly IProvaiderService provaider;

        public MovieController(
            IMovieService movies, 
            IProvaiderService provaider) 
        {
            this.movies = movies;
            this.provaider = provaider;
        }

        public IActionResult All([FromQuery]AllMoviesQueryModel query)
        {
            var queryResult = this.movies.All(
                query.Title,
                query.SearchTerm,
                query.Sorting,
                query.CurentPage,
                AllMoviesQueryModel.MoviesPerPage);

            var movieTitles = this.movies.AllTitles();

            query.Titles = movieTitles;
            query.TotalMovies = queryResult.TotalMovies;
            query.Movies = queryResult.Movies;


            return View(query);
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.provaider.IsProvaider(this.User.GetId()))
            {
                return RedirectToAction(nameof(ProvaidersController.Create), "Provaiders");
            }

            return View(new MovieFormModel
            {
                Categories = this.movies.AllCategories()
            });
        }

        [Authorize]
        public IActionResult Mine()
        {
            var myMovies = this.movies.ByUser(this.User.GetId());

            return View(myMovies);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(MovieFormModel movie)
        {
            var provaiderId = 
                this.provaider
                .IdByUser(this.User.GetId());
            
            if (provaiderId == 0)
            {
                return RedirectToAction(nameof(ProvaidersController.Create), "Provaiders");
            }

            if (!this.movies.CategoryExists(movie.CategoryId))
            {
                this.ModelState.AddModelError(nameof(movie.CategoryId),"Category dose not exist.");
            }

            if(!ModelState.IsValid)
            {
                movie.Categories = this.movies.AllCategories();

                return View(movie);
            }

            this.movies
                .Create(
                movie.Title,
                movie.Year,
                movie.Genre,
                movie.Directors,
                movie.Writers,
                movie.Stars,
                movie.Description,
                movie.ImageUrl,
                movie.CategoryId,
                provaiderId);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.GetId();

            //ako usera ne e provaider i admin
            if (!this.provaider.IsProvaider(userId) && !User.IsAdmin())
            {
                return RedirectToAction(nameof(ProvaidersController.Create), "Provaiders");
            }

            var movie = this.movies.Details(id);

            //ako filma ne e na tozi user i ne e admin 
            if (movie.UserId != userId && !User.IsAdmin())
            {
                return Unauthorized();
            }

            return View(new MovieFormModel
            {
                Title=movie.Title,
                Year=movie.Year,
                Genre=movie.Genre,
                Directors=movie.Directors,
                Writers=movie.Writers,
                Stars=movie.Stars,
                Description=movie.Description,
                ImageUrl=movie.ImageUrl,
                CategoryId=movie.CategoryId,
                Categories = this.movies.AllCategories()
            });
        }

        public IActionResult Details (int id , string information)
        {
            var movie = this.movies.Details(id);

            return View(movie);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id,MovieFormModel movie)
        {
            //purvo provaider li sme
            var provaiderId =
                this.provaider
                .IdByUser(this.User.GetId());

            //ako usera ne e provaider i admin
            if (provaiderId == 0 && !User.IsAdmin())
            {
                return RedirectToAction(nameof(ProvaidersController.Create), "Provaiders");
            }

            //kategoriqta sushetsvuva li
            if (!this.movies.CategoryExists(movie.CategoryId))
            {
                this.ModelState.AddModelError(nameof(movie.CategoryId), "Category dose not exist.");
            }

            //modelsteita validen li e
            if (!ModelState.IsValid)
            {
                movie.Categories = this.movies.AllCategories();

                return View(movie);
            }

            //tozi provaider ima li pravo da ediva tozi film
            // ako filmut ne e ot tozi provaider i ne e admin
            if (!this.movies.IsByProvaider(id,provaiderId) && !User.IsAdmin())
            {
                return BadRequest();
            }

            //i chak togava editvame
            this.movies
                .Edit(
                id,
                movie.Title,
                movie.Year,
                movie.Genre,
                movie.Directors,
                movie.Writers,
                movie.Stars,
                movie.Description,
                movie.ImageUrl,
                movie.CategoryId);

            return RedirectToAction(nameof(All));
        }
    }
}
