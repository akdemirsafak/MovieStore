using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Commands.Create
{
    public class CreateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieModel Model { get; set; }
        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {

            var movie=_context.Movies.SingleOrDefault(x=>x.Name==Model.Name);
            if (movie is not null)
            {
                throw new InvalidOperationException("Eklenecek Film Zaten Var.");
            }
            movie =_mapper.Map<Movie>(Model);
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

    }

    public class CreateMovieModel{
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}