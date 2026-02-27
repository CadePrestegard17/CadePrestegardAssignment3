namespace cprestegard_sp2026_assignment3.Models
{
    public class MovieActor
    {
        public int MovieActorId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public Movie Movie { get; set; } = null!;
        public Actor Actor { get; set; } = null!;
        public string CharacterName { get; set; } = string.Empty;
    }
}
