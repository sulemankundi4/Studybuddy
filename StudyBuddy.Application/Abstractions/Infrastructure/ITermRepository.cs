using StudyBuddy.Core.Dtos.Terms;
using StudyBuddy.Core.Entities;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Abstractions.Infrastructure
{
   public interface ITermRepository
   {
      Task CreateTermAsync(TermEntity termEntity);
      Task UpdateTermAsync(TermEntity termEntity);
      Task<IEnumerable<GetTermResponseDto>> GetAllTerms();
      Task<TermEntity?> GetTermEntityByIdAsync(Guid termId);
      Task DeleteTermAsync(Guid termId);
   }
}