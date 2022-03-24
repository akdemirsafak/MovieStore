using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Commands.Delete
{
    public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var customer=_context.Customers
            // .Include(x=>x.BoughtMovies)
            // .Include(x=>x.CustomerFavGenres).ThenInclude(x=>x.Genre)
            .SingleOrDefault(x=>x.Id==CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Silinecek müşteri bulunamadı");
            }

            else
            {
                customer.isActive = false;
                _context.SaveChanges();
            }
            
        }
    }
}