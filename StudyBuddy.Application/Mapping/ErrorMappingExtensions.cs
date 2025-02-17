using FluentValidation.Results;
using StudyBuddy.Core.Constants;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Mapping
{
   public static class ErrorMappingExtensions
   {
      public static GenericResponse<T> ToErrorResponse<T>(this List<ValidationFailure> errors)
      {
         return GenericResponse<T>.Error(ApiResponseMessages.VALIDATION_ERRORS, 400, errors.Select(x => x.ErrorMessage));
      }

      public static GenericResponse ToErrorResponse(this List<ValidationFailure> errors)
      {
         return GenericResponse.Error(ApiResponseMessages.VALIDATION_ERRORS, 400, errors.Select(x => x.ErrorMessage));
      }
   }
}