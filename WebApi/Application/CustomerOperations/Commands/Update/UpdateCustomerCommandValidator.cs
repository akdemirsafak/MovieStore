using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands.Update
{
    public class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x=>x.CustomerId).GreaterThan(0);
            RuleFor(x=>x.Model.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Model.LastName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}