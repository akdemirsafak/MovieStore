using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Commands.Update
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;

        public UpdateDirectorModel Model { get; set; }
        public int DirectorId { get; set; }


        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;

        }

        public void Handle()
        {
            var director = _context.Directors.Find(DirectorId);
            if (director is null)
            {
                throw new InvalidOperationException("Güncellenecek Yönetmen Bulunamadı.");
            }

            director.Name = Model.Name=="string" == default ? Model.Name : director.Name;
            director.LastName = Model.LastName == "string" == default ? Model.LastName : director.LastName;
            director.isActive = director.isActive != default ? Model.isActive : director.isActive;

            _context.SaveChanges();



        }
    }
    public class UpdateDirectorModel{
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; }
    }
}