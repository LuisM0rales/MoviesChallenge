using Microsoft.EntityFrameworkCore;
using MoviesCatalogueChallenge.Entities;
using MoviesCatalogueChallenge.Entities.Seeding;

namespace MoviesCatalogueChallenge.Contexts
{
    public class MoviesChContext : DbContext
    {
        public MoviesChContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitialSeeding.Seed(modelBuilder);
        }

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Rating> Ratings => Set<Rating>();
    }
}
