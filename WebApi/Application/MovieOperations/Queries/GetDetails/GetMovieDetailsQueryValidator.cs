
using FluentValidation;

namespace WebApi.Application.MovieOperations.Queries.GetDetails
{
    public class GetMovieDetailsQueryValidator: AbstractValidator<GetMovieDetailsQuery>
    {
        public GetMovieDetailsQueryValidator()
        {
            RuleFor(x=>x.MovieId).GreaterThan(0);
        
        }
    }
}