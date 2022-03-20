using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Commands.Update
{
    public class UpdateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int CustomerId { get; set; }
        public UpdateCustomerModel Model { get; set; }

        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var customer=_context.Customers.Find(CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Güncellenecek Müşteri Bulunamadı.");
            }
            customer.Name = Model.Name == "string" == default ? Model.Name : customer.Name;
            customer.LastName = Model.LastName == "string" == default ? Model.LastName : customer.LastName;
            _context.SaveChanges();
        }
    }

    public class UpdateCustomerModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; }

    }
}