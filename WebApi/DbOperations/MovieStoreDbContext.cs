using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class MovieStoreDbContext : DbContext,IMovieStoreDbContext
    {


        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {

            
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get ; set ; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
                .HasKey(m => new { m.MovieId, m.ActorId });

            // modelBuilder.Entity<MovieActor>()
            //     .HasOne<Movie>(ma =>ma.Movie)
            //     .WithMany(m => m.MovieActors)
            //     .HasForeignKey(m => m.MovieId);


            // modelBuilder.Entity<MovieActor>()
            //     .HasOne<Actor>(ma => ma.Actor)
            //     .WithMany(m => m.MovieActors)
            //     .HasForeignKey(m => m.ActorId);




        //     modelBuilder.Entity<CustomerGenre>()
        //    .HasKey(cg => new { cg.CustomerId, cg.GenreId });
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}