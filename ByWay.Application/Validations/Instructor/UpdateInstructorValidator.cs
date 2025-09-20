using ByWay.Application.DTOs.Instructor;
using FluentValidation;

namespace ByWay.Application.Validations.Instructor
{
    public class UpdateInstructorValidator : AbstractValidator<UpdateInstructorRequest>
    {
        public UpdateInstructorValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required")
           .Length(15, 150).WithMessage("Name must be between 10 and 150 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(20, 1000).WithMessage("Description must be between 20 and 1000 characters");
            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("Rate is required");

            RuleFor(x => x.JobTitle)
                .NotEmpty().WithMessage("JobTitle is required");

            RuleFor(x => x.PictureUrl)
                .NotEmpty().WithMessage("PictureUrl is required")
                .MaximumLength(300).WithMessage("PictureUrl must be less than 300 characters");
        }
    }
}
