using FluentValidation;
using StudyBuddy.Application.Validators.Base;
using StudyBuddy.Core.Dtos.Course;

namespace StudyBuddy.Application.Validators.Courses
{
   public class UpdateCourseRequestDtoValidator : BaseCoursesRequestDtosValidators<UpdateCourseRequestDto>
   {
      public UpdateCourseRequestDtoValidator()
      {
         RuleFor(x => x.TermId).NotEmpty().WithMessage("Term id is required!");
      }
   }
}