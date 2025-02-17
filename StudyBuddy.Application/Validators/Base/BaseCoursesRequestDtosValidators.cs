using FluentValidation;
using StudyBuddy.Core.BaseDtos;

namespace StudyBuddy.Application.Validators.Base
{
   public abstract class BaseCoursesRequestDtosValidators<T> : AbstractValidator<T> where T : BaseCoursesRequestDto
   {
      protected BaseCoursesRequestDtosValidators()
      {
         RuleFor(x => x.Name).NotEmpty().WithMessage("Course name is required!").MinimumLength(3).WithMessage("Course name minimum length should be 3 characters!").MaximumLength(40).WithMessage("Course name maximum length should be 40 characters!");
         RuleFor(x => x.StudyGoal).NotEmpty().WithMessage("Study goal is required!").GreaterThan(10).WithMessage("Study goal should be greater than 10 minutes!");
         RuleFor(x => x.StartDate).NotEmpty().WithMessage("Course start date is required!");
         RuleFor(x => x.EndDate).NotEmpty().WithMessage("Course end date is required!");
         RuleFor(x => x.CourseNameColor).NotEmpty().WithMessage("Course name color is required!").Matches("^#(?:[0-9a-fA-F]{3}){1,2}$").WithMessage("Course name color should be in hex format!");
         RuleFor(x => x.TermId).NotEmpty().WithMessage("Term id is required!");
      }
   }
}

