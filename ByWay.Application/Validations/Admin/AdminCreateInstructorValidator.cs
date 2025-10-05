using ByWay.Application.Abstraction.DTOs.Instructor;
using FluentValidation;

namespace ByWay.Application.Validations.Admin
{
    public class AdminCreateInstructorValidator : AbstractValidator<CreateInstructorRequest>
    {
        public AdminCreateInstructorValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Instructor name is required")
                .Length(2, 100).WithMessage("Instructor name must be between 2 and 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(10, 2000).WithMessage("Description must be between 10 and 2000 characters");

            RuleFor(x => x.JobTitle)
                .NotEmpty().WithMessage("Job title is required")
                .Length(2, 50).WithMessage("Job title must be between 2 and 50 characters");

            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("Rate is required");

            RuleFor(x => x.PictureUrl)
                .MaximumLength(300).WithMessage("Picture URL must be less than 300 characters");
        }
    }
}