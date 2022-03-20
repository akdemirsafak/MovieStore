using FluentValidation;

namespace WebApi.Application.CustomerOperations.Queries.GetDetails
{
    public class GetCustomerDetailsQueryValidator:AbstractValidator<GetCustomerDetailsQuery>
    {
        public GetCustomerDetailsQueryValidator()
        {
            RuleFor(x=>x.CustomerId).GreaterThan(0);
        }
    }
}