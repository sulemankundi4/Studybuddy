using FluentValidation;
using StudyBuddy.Application.Validators.Base;
using StudyBuddy.Core.Dtos.Terms;

namespace StudyBuddy.Application.Validators.Terms
{
   public class UpdateTermRequestDtoValidator : BaseTermsRequestDtosValidators<UpdateTermRequestDto>
   {
      public UpdateTermRequestDtoValidator()
      {
         RuleFor(x => x.TermId).NotEmpty().WithMessage("Term Id is required");
      }
   }
}