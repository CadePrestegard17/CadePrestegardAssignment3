using System.ComponentModel.DataAnnotations;

namespace cprestegard_sp2026_assignment3.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string ImdbUrl { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string PosterUrl { get; set; } = string.Empty;
        public ICollection<MovieActor> MovieActors { get; set; }
        public Movie()
        {
            MovieActors = new List<MovieActor>();
        }
    }
}
