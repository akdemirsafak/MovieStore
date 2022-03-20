using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.Create
{
    public class CreateActorCommandValidator:AbstractValidator<CreateActorCommand>
    {

       public CreateActorCommandValidator()
       {
            RuleFor(x=>x.Model.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Model.LastName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
       }   

    }
   
}