
using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetDetails
{
    public class GetGenreDetailsQueryValidator: AbstractValidator<GetGenreDetailsQuery>
    {
        public GetGenreDetailsQueryValidator()
        {
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
    }
}