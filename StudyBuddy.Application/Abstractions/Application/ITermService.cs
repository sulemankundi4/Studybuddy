using StudyBuddy.Core.Dtos.Terms;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Abstractions.Application
{
   public interface ITermService
   {
      Task<GenericResponse> CreateTermAsync(CreateTermRequestDto createTermRequestDto);
      Task<GenericResponse> UpdateTermAsync(UpdateTermRequestDto updateTermRequestDto);
      Task<GenericResponse<IEnumerable<GetTermResponseDto>>> GetTermsAsync();
      Task<GenericResponse<GetTermResponseDto>> GetTermByIdAsync(Guid termId);
      Task<GenericResponse> DeleteTermAsync(Guid termId);
   }
}