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
                        new Customer { Name = "Cem",        LastName="Yılmaz" },
                        new Customer { Name = "Ross" ,      LastName="Geller"},
                        new Customer { Name = "Chandler",   LastName="Bing"},
                        new Customer { Name = "Monica",     LastName="Geller Bing" },
                        new Customer { Name = "Joey",       LastName = "Tribbiani" }
                    );

                    context.Genres.AddRange(
                        new Genre { Name = "Bilim Kurgu" },
                        new Genre { Name = "Drama" },
                        new Genre { Name = "Aksiyon" },
                        new Genre { Name = "Fantastik" },
                        new Genre { Name = "Suç" }
                    );
                    context.Directors.AddRange(
                        new Director { Name = "Şafak",          LastName="Akdemir"},
                        new Director { Name = "Christopher",    LastName="Nolan"},//batman
                        new Director{ Name = "Francis Ford",    LastName = "Coppola"}, //
                        new Director{ Name = "Glenn",           LastName="Ficarra"}, //focus
                        new Director{ Name = "David Ford",      LastName = "Fincher" } //fight clup
                    );
                    
                    context.Actors.AddRange(
                        new Actor { Name = "Nicolas",   LastName = "Cage" ,isActive=true},
                        new Actor { Name = "Margot",    LastName = "Robbie" , isActive = true },
                        new Actor { Name = "Christian", LastName = "Bale" , isActive = true },
                        new Actor { Name = "Heath",     LastName = "Ledger" , isActive = true }, //batman
                        new Actor { Name = "Aaron",     LastName = "Eckhart" , isActive = true },//batman
                        new Actor { Name = "Al",        LastName = "Pacino" }, //Godfather
                        new Actor { Name = "James",     LastName = "Caan" }, //Godfather
                        new Actor { Name = "Bradd",     LastName = "Pitt" }, //Fight Clup
                        new Actor { Name = "Edward",    LastName = "Norton" } //Fight Clup
                    );

                    context.Movies.AddRange(
                        new Movie { Name = "The Dark Knight",   GenreId = 3, Price =100,    PublishDate = DateTime.Now.AddYears(-5),    DirectorId = 2 },
                        new Movie { Name = "Focus",             GenreId = 4, Price = 300,   PublishDate = DateTime.Now.AddYears(-3),    DirectorId = 3 },
                        new Movie { Name = "The Godfather",     GenreId = 5, Price = 200,   PublishDate = DateTime.Now.AddYears(-50),   DirectorId = 2 },
                        new Movie { Name = "Fight Club",        GenreId = 2, Price = 500,   PublishDate = DateTime.Now.AddYears(-2),    DirectorId = 5 }
                    );

                    // context.Orders.AddRange(
                    //    new Order { MovieId = 4, CustomerId = 2, Date = DateTime.Now.AddDays(-20),   Price = 100 },
                    //    new Order { MovieId = 2, CustomerId = 5, Date = DateTime.Now.AddMonths(-2),  Price = 300 }
                    // );
                    
                    context.AddRange(MovieActors);

                    // context.AddRange(CustomerGenres);

                    context.SaveChanges();

                }
            }
        }

      
        private static MovieActor[] MovieActors =
        {
            new MovieActor(){   MovieId=3,    ActorId=6 },//Godfather
            new MovieActor(){   MovieId=3,    ActorId=7 },
            new MovieActor(){   MovieId=2,    ActorId=2 }, //Focus

            new MovieActor(){   MovieId=1,    ActorId=4 }, //batman
            new MovieActor(){   MovieId=1,    ActorId=5 },
            new MovieActor(){   MovieId=4,    ActorId=3 },

            new MovieActor(){   MovieId=4,    ActorId=8 },
            new MovieActor(){   MovieId=4,    ActorId=9 }
            
        };
    //     private static CustomerGenre[] CustomerGenres =
    //    {
    //         new CustomerGenre(){   CustomerId=1,    GenreId=1 },
    //         new CustomerGenre(){   CustomerId=1,    GenreId=2 },
    //         new CustomerGenre(){   CustomerId=2,    GenreId=2 }, 

    //         new CustomerGenre(){   CustomerId=5,    GenreId=2 }, 
    //         new CustomerGenre(){   CustomerId=5,    GenreId=3 },
    //         new CustomerGenre(){   CustomerId=5,    GenreId=4 },
    //         new CustomerGenre(){   CustomerId=5,    GenreId=5 }


    //     };

    }
}