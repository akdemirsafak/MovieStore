using FluentValidation;

namespace WebApi.Application.DirectorOperations.Queries.GetDetails
{
    public class GetDirectorDetailsQueryValidator:AbstractValidator<GetDirectorDetailsQuery>
    {
        public GetDirectorDetailsQueryValidator()
        {
            RuleFor(x=>x.DirectorId).GreaterThan(0);
        }
    }
}