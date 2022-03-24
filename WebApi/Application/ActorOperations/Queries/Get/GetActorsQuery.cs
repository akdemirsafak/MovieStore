using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Queries.Get
{
    public class GetActorsQuery
    {

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<ActorViewModel> Handle()
        {
            
            var actors=_context.Actors
            .Include(x=>x.MovieActors).ThenInclude(x=>x.Movie)
            .ToList().OrderBy(x => x.Id);
            List<ActorViewModel> actorViewModels=_mapper.Map<List<ActorViewModel>>(actors);
            return actorViewModels;

        }

    }

    public class ActorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        //public bool isActive { get; set; }
        public List<string> Movies { get; set; }
        
    }
}