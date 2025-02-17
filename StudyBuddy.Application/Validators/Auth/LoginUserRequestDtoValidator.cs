using FluentValidation;
using StudyBuddy.Core.Dtos.Auth;

namespace StudyBuddy.Application.Validators
{
   public class LoginUserRequestDtoValidator : AbstractValidator<LoginUserRequestDto>
   {
      public LoginUserRequestDtoValidator()
      {
         RuleFor(x => x.Email).NotEmpty().EmailAddress();
         RuleFor(x => x.Password).NotEmpty();
      }
   }
}