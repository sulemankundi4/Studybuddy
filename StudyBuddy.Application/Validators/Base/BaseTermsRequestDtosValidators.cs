using FluentValidation;
using StudyBuddy.Core.BaseDtos;

namespace StudyBuddy.Application.Validators.Base
{
    public abstract class BaseTermsRequestDtosValidators<T> : AbstractValidator<T> where T : BaseTermRequestDto
    {
        protected BaseTermsRequestDtosValidators()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Term Name is required.")
                .MinimumLength(3).WithMessage("Term Name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Term Name must not exceed 50 characters.");

            RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id is required.");

            RuleFor(x => x.TermNumber)
                .NotEmpty().WithMessage("Term number is required.")
                .MinimumLength(1).WithMessage("Term number must be at least 1 character long.")
                .MaximumLength(10).WithMessage("Term number must not exceed 10 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Term Start date is required.")
                .LessThan(x => x.EndDate).WithMessage("Term Start date must be less than end date.");

            RuleFor(x => x.EndDate)
           .NotEmpty().WithMessage("Term End date is required.")
          .GreaterThan(x => x.StartDate).WithMessage("Term End date must be greater than start date.").Must(endDate => endDate > DateOnly.FromDateTime(DateTime.UtcNow)).WithMessage("End date must be greater than today's date.");
        }
    }
}