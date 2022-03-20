using AutoMapper;
using FluentValidation;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.Update
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
       

        public UpdateGenreCommandValidator()
        {
            
            RuleFor(x=>x.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);

        }
        
    }
}