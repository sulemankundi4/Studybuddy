using FluentValidation;
using StudyBuddy.Core.BaseDtos;

namespace StudyBuddy.Application.Validators.Base
{
   public abstract class BaseSessionRequestDtoValidator<T> : AbstractValidator<T> where T : BaseSessionRequestDto
   {
      protected BaseSessionRequestDtoValidator()
      {
         RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MinimumLength(6).WithMessage("Name must be at least 6 characters long").MaximumLength(50).WithMessage("Name must be at most 50 characters long");
         RuleFor(x => x.SessionDuration).NotEmpty().WithMessage("Session duration is required").GreaterThan(0).WithMessage("Session duration must be greater than 0");
         RuleFor(x => x.SessionDate).NotEmpty().WithMessage("Session date is required");
         RuleFor(x => x.SessionNote).MaximumLength(500).WithMessage("Session note must be at most 500 characters long");
         RuleFor(x => x.CourseId).NotEmpty().WithMessage("Session must be associated with a course");
         RuleFor(x => x.TermId).NotEmpty().WithMessage("Term id is required");
         RuleFor(x => x.ActivityId).NotEmpty().WithMessage("Session must be associated with an activity");
      }
   }
}