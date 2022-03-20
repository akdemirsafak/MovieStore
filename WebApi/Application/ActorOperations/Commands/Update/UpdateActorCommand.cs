using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Commands.Update
{
    public class UpdateActorCommand
    {

        private readonly IMovieStoreDbContext _context;
      
        public UpdateActorModel Model { get; set; }
        public int ActorId { get; set; }


        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
           
        }

        public void Handle()
        {
            var actor=_context.Actors.Find(ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Güncellenecek Aktör Bulunamadı.");
            }

            actor.Name = Model.Name == "string" == default ? Model.Name : actor.Name;
            actor.LastName = Model.LastName == "string" == default ? Model.LastName : actor.LastName;

            actor.isActive = actor.isActive != default ? Model.isActivate : actor.isActive;
        
            _context.SaveChanges();



        }

    }

    public class UpdateActorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool isActivate { get; set; }
    }
}