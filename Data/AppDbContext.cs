using cprestegard_sp2026_assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace cprestegard_sp2026_assignment3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Title = "The Shawshank Redemption",
                    ImdbUrl = "https://www.imdb.com/title/tt0111161/",
                    Genre = "Drama",
                    ReleaseYear = 1994,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg"
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "The Dark Knight",
                    ImdbUrl = "https://www.imdb.com/title/tt0468569/",
                    Genre = "Action",
                    ReleaseYear = 2008,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg"
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "Inception",
                    ImdbUrl = "https://www.imdb.com/title/tt1375666/",
                    Genre = "Sci-Fi",
                    ReleaseYear = 2010,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg"
                },
                new Movie
                {
                    MovieId = 4,
                    Title = "Pulp Fiction",
                    ImdbUrl = "https://www.imdb.com/title/tt0110912/",
                    Genre = "Crime",
                    ReleaseYear = 1994,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg"
                },
                new Movie
                {
                    MovieId = 5,
                    Title = "Forrest Gump",
                    ImdbUrl = "https://www.imdb.com/title/tt0109830/",
                    Genre = "Drama",
                    ReleaseYear = 1994,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg"
                }
            );

            // Seed Actors
            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    ActorId = 1,
                    Name = "Morgan Freeman",
                    Gender = "Male",
                    Age = 87,
                    ImdbUrl = "https://www.imdb.com/name/nm0000151/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BMTc0MDMyMzI2OF5BMl5BanBnXkFtZTcwMzM2OTk1MQ@@._V1_UX214_CR0,0,214,317_AL_.jpg"
                },
                new Actor
                {
                    ActorId = 2,
                    Name = "Tim Robbins",
                    Gender = "Male",
                    Age = 66,
                    ImdbUrl = "https://www.imdb.com/name/nm0000209/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BMTI1OTYxNzAxOF5BMl5BanBnXkFtZTYwNTE5ODI4._V1_UY317_CR16,0,214,317_AL_.jpg"
                },
                new Actor
                {
                    ActorId = 3,
                    Name = "Christian Bale",
                    Gender = "Male",
                    Age = 51,
                    ImdbUrl = "https://www.imdb.com/name/nm0000288/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BMTkxMzk4MjQ4MF5BMl5BanBnXkFtZTcwMzExODQxOA@@._V1_UX214_CR0,0,214,317_AL_.jpg"
                },
                new Actor
                {
                    ActorId = 4,
                    Name = "Heath Ledger",
                    Gender = "Male",
                    Age = 28,
                    ImdbUrl = "https://www.imdb.com/name/nm0005132/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BMTI2NTY0NzA4MF5BMl5BanBnXkFtZTYwMjE1MDE0._V1_UY317_CR17,0,214,317_AL_.jpg"
                },
                new Actor
                {
                    ActorId = 5,
                    Name = "Leonardo DiCaprio",
                    Gender = "Male",
                    Age = 50,
                    ImdbUrl = "https://www.imdb.com/name/nm0000138/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BMjI0MTg3MzI0M15BMl5BanBnXkFtZTcwMzQyODU2Mw@@._V1_UY317_CR10,0,214,317_AL_.jpg"
                },
                new Actor
                {
                    ActorId = 6,
                    Name = "Marion Cotillard",
                    Gender = "Female",
                    Age = 49,
                    ImdbUrl = "https://www.imdb.com/name/nm0182839/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BNzJhOWY4YjAtYTMzZS00MTdmLTk5NjQtMDMyNzBlZDYxYjk1XkEyXkFqcGdeQXVyMTMxMTIwMTE2._V1_UY317_CR106,0,214,317_AL_.jpg"
                },
                new Actor
                {
                    ActorId = 7,
                    Name = "John Travolta",
                    Gender = "Male",
                    Age = 71,
                    ImdbUrl = "https://www.imdb.com/name/nm0000237/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BMTUwNjQ0ODkxN15BMl5BanBnXkFtZTcwODE4MzI5OA@@._V1_UY317_CR6,0,214,317_AL_.jpg"
                },
                new Actor
                {
                    ActorId = 8,
                    Name = "Uma Thurman",
                    Gender = "Female",
                    Age = 54,
                    ImdbUrl = "https://www.imdb.com/name/nm0000235/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BMjMwNjEzNjQ2Nl5BMl5BanBnXkFtZTcwODQzNTQxNA@@._V1_UY317_CR21,0,214,317_AL_.jpg"
                },
                new Actor
                {
                    ActorId = 9,
                    Name = "Tom Hanks",
                    Gender = "Male",
                    Age = 68,
                    ImdbUrl = "https://www.imdb.com/name/nm0000158/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BMTQ2MjMwNDA3Nl5BMl5BanBnXkFtZTcwMTA2NDY3NQ@@._V1_UY317_CR2,0,214,317_AL_.jpg"
                },
                new Actor
                {
                    ActorId = 10,
                    Name = "Robin Wright",
                    Gender = "Female",
                    Age = 58,
                    ImdbUrl = "https://www.imdb.com/name/nm0000705/",
                    PhotoUrl = "https://m.media-amazon.com/images/M/MV5BMTQwMDg1NjA4NV5BMl5BanBnXkFtZTcwMTMxMjA5Nw@@._V1_UY317_CR14,0,214,317_AL_.jpg"
                }
            );

            // Seed MovieActors (Movie-Actor relationships)
            modelBuilder.Entity<MovieActor>().HasData(
                // The Shawshank Redemption
                new MovieActor { MovieActorId = 1, MovieId = 1, ActorId = 1, CharacterName = "Ellis Boyd 'Red' Redding" },
                new MovieActor { MovieActorId = 2, MovieId = 1, ActorId = 2, CharacterName = "Andy Dufresne" },

                // The Dark Knight
                new MovieActor { MovieActorId = 3, MovieId = 2, ActorId = 3, CharacterName = "Bruce Wayne / Batman" },
                new MovieActor { MovieActorId = 4, MovieId = 2, ActorId = 4, CharacterName = "Joker" },
                new MovieActor { MovieActorId = 5, MovieId = 2, ActorId = 1, CharacterName = "Lucius Fox" },

                // Inception
                new MovieActor { MovieActorId = 6, MovieId = 3, ActorId = 5, CharacterName = "Dom Cobb" },
                new MovieActor { MovieActorId = 7, MovieId = 3, ActorId = 6, CharacterName = "Mal Cobb" },

                // Pulp Fiction
                new MovieActor { MovieActorId = 8, MovieId = 4, ActorId = 7, CharacterName = "Vincent Vega" },
                new MovieActor { MovieActorId = 9, MovieId = 4, ActorId = 8, CharacterName = "Mia Wallace" },

                // Forrest Gump
                new MovieActor { MovieActorId = 10, MovieId = 5, ActorId = 9, CharacterName = "Forrest Gump" },
                new MovieActor { MovieActorId = 11, MovieId = 5, ActorId = 10, CharacterName = "Jenny Curran" }
            );
        }
    }
}
