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
            
            var actors=_context.Actors.Include(x=>x.Movies).ToList();
            List<ActorViewModel> actorViewModels=_mapper.Map<List<ActorViewModel>>(actors);
            return actorViewModels;

        }



    }

    public class ActorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}