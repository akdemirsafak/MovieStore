using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

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
            var genre=_context.Genres
            .Include(x => x.GenreCustomers).ThenInclude(x => x.Customer)
            .Include(x => x.GenreMovies)
            .SingleOrDefault(x=>x.Id.Equals(GenreId));
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
        public int HowMuchCustomerFav { get; set; }
        public bool isActive { get; set; }

        public List<string> Customers { get; set; }

        public List<string> GenreMovies { get; set; }
    }
}