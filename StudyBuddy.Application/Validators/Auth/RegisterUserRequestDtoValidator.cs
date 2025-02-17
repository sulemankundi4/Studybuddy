using FluentValidation;
using StudyBuddy.Core.Dtos.Auth;

namespace StudyBuddy.Application.Validators
{
   public class RegisterUserRequestDtoValidator : AbstractValidator<RegisterUserRequestDto>
   {
      public RegisterUserRequestDtoValidator()
      {
         RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
         RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
         RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Email is not valid.");
         RuleFor(p => p.Password).NotEmpty().WithMessage("Password cannot be empty")
                            .MinimumLength(8).WithMessage("Password length must be at least 8")
                            .MaximumLength(100).WithMessage("Password length must not exceed 100")
                            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter")
                            .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter")
                            .Matches(@"[0-9]+").WithMessage("Password must contain at least one number")
                            .Matches(@"[!@#$%^&*(),.?"":{}|<>[\]\\\/`~'=_+-]").WithMessage("Password must contain at least one special character");
      }
   }
}