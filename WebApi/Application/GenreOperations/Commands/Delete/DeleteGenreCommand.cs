using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.Delete
{
    public class DeleteGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int GenreId;

        public DeleteGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre=_context.Genres
            
            .SingleOrDefault(x=>x.Id==GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Silinecek Kategori Bulunamadı.");
            }

            genre.isActive = false;
            _context.SaveChanges();
            
        }
    }
}