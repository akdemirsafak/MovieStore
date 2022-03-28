using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Queries.Get
{
    public class GetCustomersQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CustomerViewModel> Handle()
        {
            var customers = _context.Customers
            .Include(x=>x.CustomerGenres).ThenInclude(x => x.Genre)
            .ToList().OrderBy(x=>x.Id);
            var customerViewList = _mapper.Map<List<CustomerViewModel>>(customers);
            return customerViewList;
        }
    }
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<string> FavGenres { get; set; }
    }

 

   
   
}