using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; }
        public List<Movie> BoughtMovies { get; set; } //Satın aldığı filmler
        public List<CustomerGenre> CustomerGenres { get; set; }
    }
}