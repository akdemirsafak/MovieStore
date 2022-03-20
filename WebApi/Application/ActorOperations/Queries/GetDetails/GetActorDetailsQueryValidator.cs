using FluentValidation;

namespace WebApi.Application.ActorOperations.Queries.GetDetails
{
    public class GetActorDetailsQueryValidator:AbstractValidator<GetActorDetailsQuery>
    {
        public GetActorDetailsQueryValidator()
        {
            RuleFor(x=>x.ActorId).GreaterThan(0);
        }
    }
}