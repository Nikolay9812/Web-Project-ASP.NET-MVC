using Microsoft.AspNetCore.Mvc;
using GreenFlix.Models.Api.Movies;
using GreenFlix.Services.Movies;

namespace GreenFlix.Controllers.Api
{
    [ApiController]
    [Route("api/movies")]
    public class MovieApiController:ControllerBase
    {
        private readonly IMovieService movies;

        public MovieApiController(IMovieService movies)
            =>this.movies = movies;
        

        [HttpGet]
        public MovieQueryServiceModel All([FromQuery] AllMoviesApiRequestModel query)
            => this.movies.All(
                query.Title,
                query.SearchTerm,
                query.Sorting,
                query.CurentPage,
                query.MoviesPerPage);
        
    }
}
