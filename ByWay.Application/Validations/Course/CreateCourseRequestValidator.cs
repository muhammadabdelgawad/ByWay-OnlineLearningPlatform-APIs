using ByWay.Application.DTOs.Course;
using FluentValidation;

namespace ByWay.Application.Validations.Course
{
    public class CreateCourseRequestValidator : AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseRequestValidator()
        {
            
            RuleFor(c => c.CourseName)
                .NotEmpty().WithMessage("Course name is required.")
                .MaximumLength(300).WithMessage("Course name must not exceed 300 characters.");
            
            RuleFor(c => c.PictureUrl)
                .NotEmpty().WithMessage("Picture URL is required.")
                .MaximumLength(300).WithMessage("Picture URL must not exceed 300 characters.");
          
            RuleFor(c => c.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be a non-negative value.");

            RuleFor(c => c.Description)
                 .NotEmpty().WithMessage("Description is required.")
                 .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");

            RuleFor(c => c.Certification)
                .NotEmpty().WithMessage("Certification is required.")
                .MaximumLength(300).WithMessage("Certification must not exceed 300 characters.");

            RuleFor(c => c.TotalHours)
                    .GreaterThan(0).WithMessage("Total hours must be a positive value.");

            RuleFor(c => c.Level)
                    .IsInEnum().WithMessage("Level must be a One of this valid Value { Beginner or Intermediate or Advanced or All} .");

        }
    }
}
