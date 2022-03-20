using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.Update
{
    public class UpdateGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
 
        public UpdateGenreModel Model { get; set; }
        public int GenreId { get; set; }
        public UpdateGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
            
        }

        public void Handle()
        {
            var genre=_context.Genres.SingleOrDefault(x=>x.Id==GenreId);
            if(genre is null)
            {
                throw new InvalidOperationException("Güncellenecek Kategori Bulunamadı.");
            }

            genre.Name = Model.Name == "string" == default ? Model.Name : genre.Name;
            genre.isActive = Model.isActivate != default ? Model.isActivate : genre.isActive;
            _context.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool isActivate { get; set; }
    }
}