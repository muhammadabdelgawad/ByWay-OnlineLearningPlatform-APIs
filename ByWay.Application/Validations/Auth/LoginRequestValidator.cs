using ByWay.Application.Abstraction.DTOs.Auth;
using FluentValidation;
namespace ByWay.Application.Validations.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginDto>
    {
        public LoginRequestValidator()
        {
            RuleFor(l => l.Email)
               .NotEmpty().WithMessage("Email is required")
               .EmailAddress().WithMessage("Invalid email format");
            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Password is required");
                
        }
    }
}
