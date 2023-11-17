using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static GreenFlix.Data.DataConstants.Category;

namespace GreenFlix.Data.Models
{
    public class Category
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        public IEnumerable<Movie> Movies { get; init; } = new List<Movie>();
    }
}
