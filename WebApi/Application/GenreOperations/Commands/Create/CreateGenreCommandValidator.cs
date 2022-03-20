using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.Create
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}