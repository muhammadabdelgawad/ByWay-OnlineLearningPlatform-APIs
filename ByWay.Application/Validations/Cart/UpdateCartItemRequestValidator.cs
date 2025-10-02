
namespace ByWay.Application.Validations.Cart
{
    public class UpdateCartItemRequestValidator : AbstractValidator<UpdateCartItemRequest>
    {
        public UpdateCartItemRequestValidator()
        {
            RuleFor(u => u.CourseId)
                .NotEmpty().WithMessage("Course ID is required.")
                .GreaterThan(0).WithMessage("Course ID must be greater than zero.");

            RuleFor(u => u.Quantity)
                .NotEmpty().WithMessage("Quantity is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(100).WithMessage("Quantity cannot exceed 100 items per course");
        }
    }
}
