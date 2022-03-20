using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands.Delete
{
    public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
           RuleFor(x=>x.CustomerId).GreaterThan(0); 
        }  
    }
}