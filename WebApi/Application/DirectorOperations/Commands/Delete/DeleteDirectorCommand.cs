using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Commands.Delete
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int DirectorId { get; set; }

        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors
            .Include(x => x.Movies)
            .SingleOrDefault(x => x.Id == DirectorId);

            if (director is null)
            {
                throw new InvalidOperationException("Silinecek Yönetmen Bulunamadı.");
            }
            if (director.Movies.Any())
            {
                director.isActive = false;
                
            }
            else
            {
                _context.Directors.Remove(director);
            }
            _context.SaveChanges();

        }
    }
}