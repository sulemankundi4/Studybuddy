using FluentValidation;
using StudyBuddy.Application.Validators.Base;
using StudyBuddy.Core.BaseDtos;
using StudyBuddy.Core.Dtos.Activities;

namespace StudyBuddy.Application.Validators.Activity
{
   public class CreateActivityRequestDtoValidator : BaseActivityRequestDtoValidator<CreateActivityRequestDto>
   {
      public CreateActivityRequestDtoValidator()
      {

      }
   }
}