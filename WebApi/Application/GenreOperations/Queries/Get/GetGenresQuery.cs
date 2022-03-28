using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Queries.Get
{
    public class GetGenresQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenresQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres=_context.Genres
            .Include(x=>x.GenreCustomers).ThenInclude(x=>x.Customer)
            .Include(x=>x.GenreMovies)
            .ToList().OrderBy(x => x.Id);
            List<GenreViewModel> genresViewModel=_mapper.Map<List<GenreViewModel>>(genres);
            return genresViewModel;
        }

    }
    public class GenreViewModel
    {
        public string Name { get; set; }
        public List<string> Customers { get; set; }
        public List<string> GenreMovies { get; set; }
       
        
    }
}