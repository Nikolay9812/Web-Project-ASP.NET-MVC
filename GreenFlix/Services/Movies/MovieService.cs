using GreenFlix.Data;
using GreenFlix.Data.Models;
using GreenFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly GreenFlixDbContext data;

        public MovieService(GreenFlixDbContext data)
            =>this.data = data;
        

        public MovieQueryServiceModel All(
            string title,
            string searchTerm,
            MovieSorting sorting,
            int curentPage,
            int moviesPerPage)
        {
            var moviesQuery = this.data.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                moviesQuery = moviesQuery.Where(c =>
                    c.Title == title);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                moviesQuery = moviesQuery.Where(c =>
                    (c.Title + " " + c.Genre).ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            moviesQuery = sorting switch
            {
                MovieSorting.Year => moviesQuery.OrderByDescending(c => c.Year),
                MovieSorting.TitleAndGenre => moviesQuery.OrderBy(c => c.Title).ThenBy(c => c.Genre),
                MovieSorting.DateRelesed or _ => moviesQuery.OrderByDescending(c => c.Id)
            };

            var totalMovies = moviesQuery.Count();

            var movies = GetMovies(moviesQuery
                .Skip((curentPage - 1) * moviesPerPage)
                .Take(moviesPerPage));

            return new MovieQueryServiceModel
            {
                TotalMovies = totalMovies,
                CurentPage=curentPage,
                MoviesPerPage=moviesPerPage,
                Movies=movies
            };
        }

        public IEnumerable<MovieServiceModel> ByUser(string userId)
            => GetMovies(this.data
                .Movies
                .Where(m => m.Provaider.UserId == userId));

        public IEnumerable<string> AllTitles()
            => this.data
                .Movies
                .Select(c => c.Title)
                .Distinct()
                .OrderBy(genr => genr)
                .ToList();

        //celta na tozi vunshen metod e da ne kopi peistvame edin i susht kod,posle s automaper shte bude
        //napulno izlishen,no tova e pravilna praktika.
        private static IEnumerable<MovieServiceModel> GetMovies(IQueryable<Movie> movieQuery)
            => movieQuery
            .Select(m => new MovieServiceModel
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                Genre = m.Genre,
                Directors = m.Directors,
                Writers = m.Writers,
                Stars = m.Stars,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                CategoryName = m.Category.Name
            })
            .ToList();

        public IEnumerable<MovieCategoryServiceModel> AllCategories()
            => this.data
                .Categories
                .Select(c => new MovieCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        public MovieDetailsServiceModel Details(int id)
            => this.data
            .Movies
            .Where(m => m.Id == id) //kazvam q mi nameri tozi film koito suvpada s tova id
            .Select(m => new MovieDetailsServiceModel //sled tova mi na-mapni tozi model
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                Genre = m.Genre,
                Directors = m.Directors,
                Writers = m.Writers,
                Stars = m.Stars,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                CategoryId = m.CategoryId,
                CategoryName = m.Category.Name,
                ProvaiderId = m.ProvaiderId,
                ProvaiderName = m.Provaider.Name,
                UserId = m.Provaider.UserId
            })
            .FirstOrDefault();

        public bool CategoryExists(int categoryId)
            => this.data
            .Categories
            .Any(c => c.Id == categoryId);

        public int Create(string title, int year, string genre, string directors, string writers, string stars, string description, string imageUrl, int categoryId, int provaiderId)
        {
            var movieData = new Movie
            {
                Title = title,
                Year = year,
                Genre = genre,
                Directors = directors,
                Writers = writers,
                Stars = stars,
                Description = description,
                ImageUrl = imageUrl,
                CategoryId = categoryId,
                ProvaiderId = provaiderId
            };

            this.data.Add(movieData);
            this.data.SaveChanges();

            return movieData.Id;
        }

        public bool Edit(int id, string title, int year, string genre, string directors, string writers, string stars, string description, string imageUrl, int categoryId)
        {
            var movieData = this.data.Movies.Find(id);

            if (movieData == null)
            {
                return false;
            }

            movieData.Title = title;
            movieData.Year = year;
            movieData.Genre = genre;
            movieData.Directors = directors;
            movieData.Writers = writers;
            movieData.Stars = stars;
            movieData.Description = description;
            movieData.ImageUrl = imageUrl;
            movieData.CategoryId = categoryId;
            
            this.data.SaveChanges();

            return true;
        }

        public bool IsByProvaider(int movieId, int provaiderId)
            => this.data
            .Movies
            .Any(m => m.Id == movieId && m.ProvaiderId == provaiderId);
    }
}
