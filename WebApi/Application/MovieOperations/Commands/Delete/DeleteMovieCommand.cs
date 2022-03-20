using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Commands.Delete
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int MovieId;

        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie=_context.Movies.SingleOrDefault(x=>x.Id==MovieId);
            if (movie is null)
            {
                throw new InvalidOperationException("Silinecek Film Bulunamadı.");
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}