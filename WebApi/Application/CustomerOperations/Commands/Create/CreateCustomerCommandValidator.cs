using FluentValidation;


namespace WebApi.Application.CustomerOperations.Commands.Create
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Model.LastName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}