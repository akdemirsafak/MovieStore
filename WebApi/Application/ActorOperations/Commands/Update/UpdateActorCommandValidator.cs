using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.Update
{
    public class UpdateActorCommandValidator:AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x=>x.ActorId).GreaterThan(0);
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(3).MaximumLength(50);

            RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);

            // RuleFor(x => x.Model.isActivate).
        }
    }
}