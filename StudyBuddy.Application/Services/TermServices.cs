using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Application.Validators;
using StudyBuddy.Application.Validators.Terms;
using StudyBuddy.Core.Constants;
using StudyBuddy.Core.Dtos.Terms;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Services
{
   public class TermServices : ITermService
   {
      private readonly ITermRepository _termRepository;

      public TermServices(ITermRepository termRepository)
      {
         _termRepository = termRepository;
      }

      public async Task<GenericResponse> CreateTermAsync(CreateTermRequestDto createTermRequestDto)
      {
         var validator = new CreateTermRequestDtoValidator();
         var validationResult = validator.Validate(createTermRequestDto);

         if (!validationResult.IsValid)
         {
            return validationResult.Errors.ToErrorResponse();
         }

         var termEntity = createTermRequestDto.Map();

         await _termRepository.CreateTermAsync(termEntity);
         return GenericResponse.Success(ApiResponseMessages.TERM_CREATED_SUCCESSFULLY, 200);
      }

      public async Task<GenericResponse> UpdateTermAsync(UpdateTermRequestDto updateTermRequestDto)
      {
         var validator = new UpdateTermRequestDtoValidator();
         var validationResult = validator.Validate(updateTermRequestDto);
         if (!validationResult.IsValid)
         {
            return validationResult.Errors.ToErrorResponse();
         }

         var termEntity = await _termRepository.GetTermEntityByIdAsync(updateTermRequestDto.TermId);
         if (termEntity == null)
         {
            return GenericResponse.Failure(ApiResponseMessages.TERM_NOT_FOUND, 404);
         }

         updateTermRequestDto.Map(termEntity);
         await _termRepository.UpdateTermAsync(termEntity);

         return GenericResponse.Success(ApiResponseMessages.TERM_UPDATED_SUCCESSFULLY, 200);
      }

      public async Task<GenericResponse<IEnumerable<GetTermResponseDto>>> GetTermsAsync(Guid userId)
      {
         var terms = await _termRepository.GetAllTerms(userId);
         if (terms == null || !terms.Any())
         {
            return GenericResponse<IEnumerable<GetTermResponseDto>>.Failure(ApiResponseMessages.NO_TERMS_FOUND, 404);
         }

         return GenericResponse<IEnumerable<GetTermResponseDto>>.Success(terms, ApiResponseMessages.RECORD_FOUND, 200);
      }

      public async Task<GenericResponse<GetTermResponseDto>> GetTermByIdAsync(Guid termId)
      {
         var term = await _termRepository.GetTermEntityByIdAsync(termId);
         if (term == null)
         {
            return GenericResponse<GetTermResponseDto>.Failure(ApiResponseMessages.TERM_NOT_FOUND, 404);
         }
         var responseDto = term.Map();
         return GenericResponse<GetTermResponseDto>.Success(responseDto, ApiResponseMessages.RECORD_FOUND, 200);
      }

      public async Task<GenericResponse> DeleteTermAsync(Guid termId)
      {
         var term = await _termRepository.GetTermEntityByIdAsync(termId);

         if (term != null)
         {
            await _termRepository.DeleteTermAsync(termId);
            return GenericResponse.Success(ApiResponseMessages.TERM_DELETED_SUCCESSFULLY, 200);
         }

         return GenericResponse.Success(ApiResponseMessages.NO_RECORD_FOUND, 404);
      }
   }
}