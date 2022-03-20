using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.Delete
{
    public class DeleteDirectorCommandValidator:AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(x=>x.DirectorId).GreaterThan(0);
        }
    }
}