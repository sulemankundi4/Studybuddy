using FluentValidation;
using StudyBuddy.Core.BaseDtos;

namespace StudyBuddy.Application.Validators.Base
{
   public abstract class BaseActivityRequestDtoValidator<T> : AbstractValidator<T> where T : BaseActivityRequestDto
   {
      protected BaseActivityRequestDtoValidator()
      {
         RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MinimumLength(5).WithMessage("Activity name must be at least 5 characters long.").MaximumLength(50).WithMessage("Activity name must not exceed 50 characters.");
         RuleFor(x => x.TermId).NotEmpty().WithMessage("TermId is required.");
      }
   }
}