using FluentValidation;
using StudyBuddy.Application.Validators.Base;
using StudyBuddy.Core.Dtos.Course;

namespace StudyBuddy.Application.Validators.Courses
{
   public class CreateCourseRequestDtoValidator : BaseCoursesRequestDtosValidators<CreateCourseRequestDto>
   {
      public CreateCourseRequestDtoValidator()
      {

      }
   }
}