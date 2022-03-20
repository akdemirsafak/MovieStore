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

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}