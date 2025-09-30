using ByWay.Application.Abstraction.DTOs.Auth;
using FluentValidation;

namespace ByWay.Application.Validations.Auth
{
    public class RegisterRequestValidator :AbstractValidator<RegisterDto>
    {
        public RegisterRequestValidator()
        {
            RuleFor(r=>r.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("A valid email is required");
            RuleFor(r=>r.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(4).WithMessage("Password must be at least 4 characters ");
            RuleFor(r=>r.UserName)
                .NotEmpty().WithMessage("Username is required")
                .Length(3,100).WithMessage("Username must be at least 3 min and 100max characters ");
            RuleFor(r=>r.DisplayName)
                .NotEmpty().WithMessage("DisplayName is required")
                .Length(5,100).WithMessage("DisplayName must be at least 5 min and 100max characters ");
        }
    }
}
