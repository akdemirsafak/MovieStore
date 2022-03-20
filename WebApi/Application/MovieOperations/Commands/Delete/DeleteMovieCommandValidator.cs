using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.Delete
{
    public class DeleteMovieCommandValidator:AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            
        }
    }
}