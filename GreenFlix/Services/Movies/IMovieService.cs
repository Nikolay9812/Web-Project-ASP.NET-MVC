using GreenFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Services.Movies
{
    public interface IMovieService
    {
        MovieQueryServiceModel All(
            string title,
            string searchTerm,
            MovieSorting sorting,
            int curentPage,
            int moviesPerPage);

        MovieDetailsServiceModel Details(int movieId);

        int Create(
            string title,
            int year,
            string genre,
            string directors,
            string writers,
            string stars,
            string description,
            string imageUrl,
            int categoryId,
            int provaiderId);

        bool Edit(
            int movieId,
            string title,
            int year,
            string genre,
            string directors,
            string writers,
            string stars,
            string description,
            string imageUrl,
            int categoryId);

        IEnumerable<MovieServiceModel> ByUser(string userId);

        IEnumerable<string> AllTitles();

        IEnumerable<MovieCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);

        bool IsByProvaider(int movieId, int provaiderId);
    }
}
