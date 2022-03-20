using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.Create
{
    public class CreateGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreModel Model { get; set; }
        public CreateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {

            var genre=_context.Genres.SingleOrDefault(x=>x.Name==Model.Name);
            if (genre is not null)
            {
                throw new InvalidOperationException("Eklenecek Kategori Zaten Var.");
            }
            genre=_mapper.Map<Genre>(Model);
            // genre.isActivate=true; Default olarak true;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

    }

    public class CreateGenreModel{
        public string Name { get; set; }
        
    }
}