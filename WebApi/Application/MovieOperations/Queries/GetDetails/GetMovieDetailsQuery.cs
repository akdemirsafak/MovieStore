using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries.GetDetails
{
    public class GetMovieDetailsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }
        public GetMovieDetailsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovieDetailsViewModel Handle()
        {
            var movie=_context.Movies
            .Include(x=>x.Director)
            .Include(x=>x.Genre)
            .Include(x=>x.MovieActors).ThenInclude(x=>x.Actor)
            .SingleOrDefault(x=>x.Id.Equals(MovieId));
            if (movie is null)
            {
                throw new Exception("Görüntülenecek Film Bulunamadı.");
            }
            else
            {
                var movieDvm = _mapper.Map<MovieDetailsViewModel>(movie);
                return movieDvm;
            }
           
        }
    }

    public class MovieDetailsViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public decimal Price { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }

        public List<string> MovieActors { get; set; }
    }
   
}