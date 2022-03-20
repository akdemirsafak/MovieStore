using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetDetails
{
    public class GetGenreDetailsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public GetGenreDetailsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailsViewModel Handle()
        {
            var genre=_context.Genres.SingleOrDefault(x=>x.Id.Equals(GenreId));
            if (genre is null)
            {
                throw new Exception("Görüntülenecek Kategori Bulunamadı.");
            }
            else
            {
                var genreDvm = _mapper.Map<GenreDetailsViewModel>(genre);
                return genreDvm;
            }
            
        }
    }

    public class GenreDetailsViewModel
    {
        public string Name { get; set; }
    }
}