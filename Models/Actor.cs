using System.ComponentModel.DataAnnotations;

namespace cprestegard_sp2026_assignment3.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string ImdbUrl { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public ICollection<MovieActor> MovieActors { get; set; }
        public Actor()
        {
            MovieActors = new List<MovieActor>();
        }
    }
}
