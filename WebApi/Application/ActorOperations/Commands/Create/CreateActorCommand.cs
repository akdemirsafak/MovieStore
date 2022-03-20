using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Commands.Create
{
    public class CreateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorModel Model { get; set; }
        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Handle()
        {
            var actor=_context.Actors.SingleOrDefault(x=>x.Name==Model.Name && x.LastName==Model.LastName);
            if (actor is not null)
            {
                throw new InvalidOperationException("Bu Aktör Zaten Kayıtlı.");
            }
            actor=_mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();

        }


    }
    public class CreateActorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        
    }
}