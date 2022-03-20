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
            var genre=_context.Genres.Include(x=>x.Movies).SingleOrDefault(x=>x.Id==GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Silinecek Kategori Bulunamadı.");
            }
            
            if(genre.Movies.Any()){
                genre.isActive =false;
                
            }
            else{
                _context.Genres.Remove(genre);
            }
            
            _context.SaveChanges();
            
        }
    }
}