using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieShop.Models;

namespace MovieShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(a => new { a.ActorID, a.MovieID });
            modelBuilder.Entity<MovieActor>().HasOne(m => m.Movie).WithMany(a => a.MovieActors).HasForeignKey(m => m.MovieID);
            modelBuilder.Entity<MovieActor>().HasOne(m => m.Actor).WithMany(a => a.MovieActors).HasForeignKey(m => m.ActorID);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<MovieActor> MovieActors { get; set; } = default!;
        public DbSet<Cinema> Cinemas { get; set; } = default!;

        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
    }
}
