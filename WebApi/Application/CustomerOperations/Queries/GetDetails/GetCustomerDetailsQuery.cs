using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Queries.GetDetails
{
    public class GetCustomerDetailsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int CustomerId { get; set; }
        public GetCustomerDetailsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CustomerDetailsViewModel Handle()
        {
            var customer = _context.Customers.Find(CustomerId);
            if(customer is null)
            {
                throw new InvalidOperationException("Bu Müşteri Bulunamadı.");
            }
            var customerViewList = _mapper.Map<CustomerDetailsViewModel>(customer);
            return customerViewList;
            
        }
    }
    public class CustomerDetailsViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }        
    }
}