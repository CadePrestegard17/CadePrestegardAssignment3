using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cprestegard_sp2026_assignment3.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "Age", "Gender", "ImdbUrl", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, 87, "Male", "https://www.imdb.com/name/nm0000151/", "Morgan Freeman", "https://m.media-amazon.com/images/M/MV5BMTc0MDMyMzI2OF5BMl5BanBnXkFtZTcwMzM2OTk1MQ@@._V1_UX214_CR0,0,214,317_AL_.jpg" },
                    { 2, 66, "Male", "https://www.imdb.com/name/nm0000209/", "Tim Robbins", "https://m.media-amazon.com/images/M/MV5BMTI1OTYxNzAxOF5BMl5BanBnXkFtZTYwNTE5ODI4._V1_UY317_CR16,0,214,317_AL_.jpg" },
                    { 3, 51, "Male", "https://www.imdb.com/name/nm0000288/", "Christian Bale", "https://m.media-amazon.com/images/M/MV5BMTkxMzk4MjQ4MF5BMl5BanBnXkFtZTcwMzExODQxOA@@._V1_UX214_CR0,0,214,317_AL_.jpg" },
                    { 4, 28, "Male", "https://www.imdb.com/name/nm0005132/", "Heath Ledger", "https://m.media-amazon.com/images/M/MV5BMTI2NTY0NzA4MF5BMl5BanBnXkFtZTYwMjE1MDE0._V1_UY317_CR17,0,214,317_AL_.jpg" },
                    { 5, 50, "Male", "https://www.imdb.com/name/nm0000138/", "Leonardo DiCaprio", "https://m.media-amazon.com/images/M/MV5BMjI0MTg3MzI0M15BMl5BanBnXkFtZTcwMzQyODU2Mw@@._V1_UY317_CR10,0,214,317_AL_.jpg" },
                    { 6, 49, "Female", "https://www.imdb.com/name/nm0182839/", "Marion Cotillard", "https://m.media-amazon.com/images/M/MV5BNzJhOWY4YjAtYTMzZS00MTdmLTk5NjQtMDMyNzBlZDYxYjk1XkEyXkFqcGdeQXVyMTMxMTIwMTE2._V1_UY317_CR106,0,214,317_AL_.jpg" },
                    { 7, 71, "Male", "https://www.imdb.com/name/nm0000237/", "John Travolta", "https://m.media-amazon.com/images/M/MV5BMTUwNjQ0ODkxN15BMl5BanBnXkFtZTcwODE4MzI5OA@@._V1_UY317_CR6,0,214,317_AL_.jpg" },
                    { 8, 54, "Female", "https://www.imdb.com/name/nm0000235/", "Uma Thurman", "https://m.media-amazon.com/images/M/MV5BMjMwNjEzNjQ2Nl5BMl5BanBnXkFtZTcwODQzNTQxNA@@._V1_UY317_CR21,0,214,317_AL_.jpg" },
                    { 9, 68, "Male", "https://www.imdb.com/name/nm0000158/", "Tom Hanks", "https://m.media-amazon.com/images/M/MV5BMTQ2MjMwNDA3Nl5BMl5BanBnXkFtZTcwMTA2NDY3NQ@@._V1_UY317_CR2,0,214,317_AL_.jpg" },
                    { 10, 58, "Female", "https://www.imdb.com/name/nm0000705/", "Robin Wright", "https://m.media-amazon.com/images/M/MV5BMTQwMDg1NjA4NV5BMl5BanBnXkFtZTcwMTMxMjA5Nw@@._V1_UY317_CR14,0,214,317_AL_.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Genre", "ImdbUrl", "PosterUrl", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Drama", "https://www.imdb.com/title/tt0111161/", "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg", 1994, "The Shawshank Redemption" },
                    { 2, "Action", "https://www.imdb.com/title/tt0468569/", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg", 2008, "The Dark Knight" },
                    { 3, "Sci-Fi", "https://www.imdb.com/title/tt1375666/", "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg", 2010, "Inception" },
                    { 4, "Crime", "https://www.imdb.com/title/tt0110912/", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", 1994, "Pulp Fiction" },
                    { 5, "Drama", "https://www.imdb.com/title/tt0109830/", "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg", 1994, "Forrest Gump" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieActorId", "ActorId", "CharacterName", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, "Ellis Boyd 'Red' Redding", 1 },
                    { 2, 2, "Andy Dufresne", 1 },
                    { 3, 3, "Bruce Wayne / Batman", 2 },
                    { 4, 4, "Joker", 2 },
                    { 5, 1, "Lucius Fox", 2 },
                    { 6, 5, "Dom Cobb", 3 },
                    { 7, 6, "Mal Cobb", 3 },
                    { 8, 7, "Vincent Vega", 4 },
                    { 9, 8, "Mia Wallace", 4 },
                    { 10, 9, "Forrest Gump", 5 },
                    { 11, 10, "Jenny Curran", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "MovieActorId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 5);
        }
    }
}
