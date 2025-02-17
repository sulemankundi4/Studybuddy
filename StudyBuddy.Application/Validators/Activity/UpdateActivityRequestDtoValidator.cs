using FluentValidation;
using StudyBuddy.Application.Validators.Base;
using StudyBuddy.Core.Dtos.Activities;

namespace StudyBuddy.Application.Validators.Activity
{
   public class UpdateActivityRequestDtoValidator : BaseActivityRequestDtoValidator<UpdateActivityRequestDto>
   {
      public UpdateActivityRequestDtoValidator()
      {
         RuleFor(x => x.ActivityId).NotEmpty().WithMessage("ActivityId is required.");
      }
   }
}