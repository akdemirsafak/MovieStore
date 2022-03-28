using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Queries.GetDetails
{
    public class GetActorDetailsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int ActorId { get; set; }
        public GetActorDetailsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDetailsViewModel Handle()
        {
            var actor=_context.Actors
            .Include(x=>x.MovieActors).ThenInclude(x=>x.Movie)
            .SingleOrDefault(x=>x.Id==ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Bu Aktör Bulunamadı.");
            }
            ActorDetailsViewModel actorDetailsViewModel=_mapper.Map<ActorDetailsViewModel>(actor);
            return actorDetailsViewModel;
        }
        
    }
    public class ActorDetailsViewModel 
    { 
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; }
        public List<string> Movies { get; set; }
        
    }
}