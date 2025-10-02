using FluentValidation;

namespace ByWay.Application.Validations.Cart
{
    public class CreateCartItemRequestValidator :AbstractValidator<CreateCartItemRequest>
    {
        public CreateCartItemRequestValidator()
        {
            RuleFor(c => c.CourseName)
                 .NotEmpty().WithMessage("Course name is required.")
                 .NotNull().WithMessage("Course name cannot be null.")
                 .Length(5, 200).WithMessage("Course name must not exceed 200 characters and min 5");
                 

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");

            RuleFor(c => c.Quantity)
                .NotEmpty().WithMessage("Quantity is required.")
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(100)
                .WithMessage("Quantity cannot exceed 100 items per course.");

            RuleFor(c => c.PictureUrl)
                .MaximumLength(500)
                .WithMessage("Picture URL must not exceed 500 characters.");
                
        }
    }
}
