namespace WebApi.Entities
{
    public class CustomerGenre
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}