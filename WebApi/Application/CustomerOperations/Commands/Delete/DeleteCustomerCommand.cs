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
            var customer=_context.Customers.Include(x=>x.BoughtMovies).Include(x=>x.FavoriteGenres).SingleOrDefault(x=>x.Id==CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Silinecek müşteri bulunamadı");
            }
            if (customer.BoughtMovies.Any() || customer.FavoriteGenres.Any())
            {
                customer.isActive=false;
            }
            else
            {
                _context.Customers.Remove(customer);
            }
            _context.SaveChanges();
        }
    }
}