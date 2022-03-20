using AutoMapper;
using WebApi.DbOperations;


namespace WebApi.Application.MovieOperations.Commands.Update
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateMovieModel Model { get; set; }
        public int MovieId { get; set; }
        public UpdateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie=_context.Movies.SingleOrDefault(x=>x.Id==MovieId);
            if(movie is null)
            {
                throw new InvalidOperationException("Güncellenecek Film Bulunamadı.");
            }

            movie.Name = Model.Name == "string" == default ? Model.Name : movie.Name;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;
            movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
            movie.DirectorId = Model.DirectorId != default ? Model.DirectorId : movie.DirectorId;
            movie.PublishDate=Model.PublishDate!=default? Model.PublishDate : movie.PublishDate;

            _context.SaveChanges();
        }
    }
    public class UpdateMovieModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}