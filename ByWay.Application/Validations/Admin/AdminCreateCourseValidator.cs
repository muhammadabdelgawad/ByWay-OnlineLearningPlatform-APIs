using ByWay.Application.Abstraction.DTOs.Course;
using FluentValidation;

namespace ByWay.Application.Validations.Admin
{
    public class AdminCreateCourseValidator : AbstractValidator<CreateCourseRequest>
    {
        public AdminCreateCourseValidator()
        {
            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("Course name is required")
                .Length(3, 200).WithMessage("Course name must be between 3 and 200 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Course description is required")
                .Length(10, 2000).WithMessage("Description must be between 10 and 2000 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Course price must be greater than 0");

            RuleFor(x => x.TotalHours)
                .GreaterThan(0).WithMessage("Total hours must be greater than 0");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Please select a valid category");

            RuleFor(x => x.InstructorId)
                .GreaterThan(0).WithMessage("Please select a valid instructor");

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage("Course level is required");

            RuleFor(x => x.PictureUrl)
                .MaximumLength(300).WithMessage("Picture URL must be less than 300 characters");
        }
    }
}