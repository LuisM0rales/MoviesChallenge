using Microsoft.EntityFrameworkCore;

namespace MoviesCatalogueChallenge.Entities.Seeding
{
    public class InitialSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var adminRole = new Role { RoleId = 1, Name = "admin"};
            var normalRole = new Role { RoleId = 2, Name = "user" };
            modelBuilder.Entity<Role>().HasData(adminRole, normalRole);

            var admin = new User { UserId = 1, Email = "admin@admin.com", Password = "admin", RoleId = 1 };
            var normal = new User { UserId = 2, Email = "user@normal.com", Password = "normal", RoleId = 2 };
            modelBuilder.Entity<User>().HasData(admin, normal);

            var sciFiCategory = new Category { CategoryId= 1, Name = "Science Fiction" };
            var comedyCategory = new Category { CategoryId= 2, Name = "Comedy" };
            var actionCategory = new Category { CategoryId= 3, Name = "Action" };
            var horroCategory = new Category { CategoryId= 4, Name = "Horror" };
            var DramaCategory = new Category { CategoryId= 5, Name = "Drama" };
            modelBuilder.Entity<Category>().HasData(sciFiCategory, comedyCategory, actionCategory, horroCategory, DramaCategory);

            var starWars = new Movie
            {
                MovieId = 1,
                Name = "Star Wars: A New Hope",
                ReleaseYear = 1977,
                Synopsis = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.",
                Poster = new byte[0],
                CategoryId = 1,
                UserId = 1,
                CreatedDate = DateTime.Now.AddDays(-30)
            };
            var shawshank = new Movie
            {
                MovieId = 2,
                Name = "The Shawshank Redemption",
                ReleaseYear = 1994,
                Synopsis = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Poster = new byte[0],
                CategoryId = 5,
                UserId = 1,
                CreatedDate = DateTime.Now.AddDays(-60)
            };
            var godFather = new Movie
            {
                MovieId = 3,
                Name = "The Godfather",
                ReleaseYear = 1972,
                Synopsis = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                Poster = new byte[0],
                CategoryId = 5,
                UserId = 1,
                CreatedDate = DateTime.Now.AddDays(-90)
            };
            modelBuilder.Entity<Movie>().HasData(starWars, shawshank, godFather);
        }                                                                          
    }                                                                              
}
