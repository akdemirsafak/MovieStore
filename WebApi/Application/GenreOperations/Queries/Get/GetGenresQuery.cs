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
    
            .ToList().OrderBy(x => x.Id);
            List<GenreViewModel> genresViewModel=_mapper.Map<List<GenreViewModel>>(genres);
            return genresViewModel;
        }

    }
    public class GenreViewModel
    {
        public string Name { get; set; }
       
        
    }
}