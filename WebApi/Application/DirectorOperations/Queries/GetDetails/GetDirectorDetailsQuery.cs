using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries.GetDetails
{
    public class GetDirectorDetailsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int DirectorId { get; set; }
        public GetDirectorDetailsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public DirectorDetailsViewModel Handle()
        {
            var director=_context.Directors.Include(x=>x.Movies).SingleOrDefault(x=>x.Id==DirectorId);
            if (director is null)
            {
                throw new Exception("Görüntülenecek Yönetmen Bulunamadı.");
            }
            else
            {
                var directorDvm = _mapper.Map<DirectorDetailsViewModel>(director);
                return directorDvm;
            }
        }



    }

    public class DirectorDetailsViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        //public List<Movie> Movies { get; set; }
    }
}