using Application.Authentication.Queries;
using FluentValidation;

namespace Application.Authentication.Commands.Register
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Password).NotEmpty();
        }
    }

}
