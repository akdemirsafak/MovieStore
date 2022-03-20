using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.Create
{
    public class CreateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerModel Model { get; set; }
        public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer=_context.Customers.SingleOrDefault(x=>x.Name==Model.Name && x.LastName==Model.LastName);
            if (customer is not null)
            {
                throw new InvalidOperationException("Bu Müşteri Zaten Kayıtlı");
            }
            if (Model.Name=="string" || Model.LastName=="string")
            {
                throw new InvalidOperationException("Müşteri Adı veya Soyadını Ayarlayınız.");
            }

            customer = _mapper.Map<Customer>(Model);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

    }
    public class CreateCustomerModel{
        public string Name { get; set; }
        public string LastName { get; set; }

    }
}