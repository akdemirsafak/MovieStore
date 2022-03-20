using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.Update
{
    public class UpdateDirectorCommandValidator:AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(x=>x.DirectorId).GreaterThan(0);
            RuleFor(x=>x.Model.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Model.LastName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}