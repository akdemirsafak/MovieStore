using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.Create
{
    public class CreateDirectorCommandValidator:AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x=>x.Model.LastName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}