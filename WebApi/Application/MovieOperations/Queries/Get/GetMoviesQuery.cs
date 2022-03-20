using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries.Get
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movies=_context.Movies.Include(x=>x.Director).Include(x=>x.Genre).ToList(); //.Include(x => x.Actors)
           //Film var.
            List<MovieViewModel> moviesViewModel=_mapper.Map<List<MovieViewModel>>(movies);
            return moviesViewModel;
        }

    }
    public class MovieViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public decimal Price { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
     
        public List<Actor> Actors { get; set; }
    }
}