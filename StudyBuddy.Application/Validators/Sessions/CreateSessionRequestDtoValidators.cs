using FluentValidation;
using StudyBuddy.Application.Validators.Base;
using StudyBuddy.Core.Dtos.Session;

namespace StudyBuddy.Application.Validators.Sessions
{
   public class CreateSessionRequestDtoValidators : BaseSessionRequestDtoValidator<CreateSessionRequestDto>
   {
      public CreateSessionRequestDtoValidators()
      {

      }
   }
}