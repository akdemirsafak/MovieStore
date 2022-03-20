using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Commands.Delete
{
    public class DeleteActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int ActorId { get; set; }

        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor=_context.Actors.Include(x=>x.Movies).SingleOrDefault(x=>x.Id==ActorId);
            
            if (actor is null)
            {
                throw new InvalidOperationException("Silinecek Aktör Bulunamadı.");
            }
            if (actor.Movies.Any())
            {
                actor.isActive = false;

            }
            else
            {
                _context.Actors.Remove(actor);
            }

            _context.SaveChanges();
        }
    }
}