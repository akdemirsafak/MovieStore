
using FluentValidation;


namespace WebApi.Application.MovieOperations.Commands.Update
{
    public class UpdateMovieCommandValidator:AbstractValidator<UpdateMovieCommand>
    {
       
        public UpdateMovieCommandValidator()
        {

            RuleFor(x=>x.MovieId).GreaterThan(0);
            RuleFor(x => x.Model.DirectorId).GreaterThan(0);
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Model.Price).GreaterThan(0);
            

        }
        
    }
}