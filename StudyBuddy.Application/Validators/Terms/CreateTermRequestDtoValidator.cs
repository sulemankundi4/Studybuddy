using FluentValidation;
using StudyBuddy.Application.Validators.Base;
using StudyBuddy.Core.Dtos.Terms;

namespace StudyBuddy.Application.Validators
{
  public class CreateTermRequestDtoValidator : BaseTermsRequestDtosValidators<CreateTermRequestDto>
  {
    public CreateTermRequestDtoValidator()
    {
      RuleFor(x => x.Goals.WeekDayStudyTime)
        .NotEmpty().WithMessage("Weekday study time is required.")
        .GreaterThan(0).WithMessage("Weekday study time must be greater than 0 minute").LessThan(500).WithMessage("Weekday study time must be less than 500 minutes.");

      RuleFor(x => x.Goals.WeekEndStudyTime).NotEmpty().WithMessage("Weekend study time is required.")
        .GreaterThan(0).WithMessage("Weekend study time must be greater than 0 minute").LessThan(500).WithMessage("Weekend study time must be less than 500 minutes.");
    }
  }
}