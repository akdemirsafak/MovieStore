using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())//eğer data varsa
                {
                    return;
                }
                else
                {
                    context.Customers.AddRange(
                        new Customer { Name = "Cem",LastName="Yılmaz" },
                        new Customer { Name = "Ross" ,LastName="Geller"},
                        new Customer { Name = "Chandler" ,LastName="Bing"},
                        new Customer { Name = "Monica", LastName="Geller Bing" },
                               new Customer { Name = "Joey", LastName = "Tribbiani" }

                    );

                    context.Genres.AddRange(
                        new Genre { Name = "Bilim Kurgu" },
                        new Genre { Name = "Dram" },
                        new Genre { Name = "Aksiyon" },
                        new Genre { Name = "Fantastik" }

                    );
                    context.Directors.AddRange(
                        new Director { Name = "Şafak", LastName="Akdemir"},
                        new Director { Name = "Sedanur", LastName="Cosgun"}

                    );
                    context.Actors.AddRange(
                        new Actor { Name = "Nicolas", LastName = "Cage" },
                        new Actor { Name = "Margot", LastName = "Robbie" }

                    );
                    context.Movies.AddRange(
                        new Movie { Name = "The Batman",GenreId=1, Price=100,PublishDate=DateTime.Now.AddYears(-2),DirectorId=1},
                        new Movie { Name = "Focus", GenreId = 4, Price = 100, PublishDate = DateTime.Now.AddYears(-3), DirectorId = 2 }
                        
                    );
                    context.SaveChanges();
                }
            }
        }

    }
}