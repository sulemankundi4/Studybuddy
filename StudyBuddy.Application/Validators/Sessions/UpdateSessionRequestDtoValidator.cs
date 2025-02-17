using FluentValidation;
using StudyBuddy.Application.Validators.Base;
using StudyBuddy.Core.Dtos.Session;

namespace StudyBuddy.Application.Validators.Sessions
{
   public class UpdateSessionRequestDtoValidator : BaseSessionRequestDtoValidator<UpdateSessionRequestDto>
   {
      public UpdateSessionRequestDtoValidator()
      {
         RuleFor(x => x.SessionId).NotEmpty().WithMessage("Session id is required");
      }
   }
}