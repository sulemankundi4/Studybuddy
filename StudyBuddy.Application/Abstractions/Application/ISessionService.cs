
using System.Linq.Expressions;
using StudyBuddy.Core.Dtos.Session;
using StudyBuddy.Core.Entities;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Abstractions.Application
{
   public interface ISessionService
   {
      Task<GenericResponse> CreateSession(CreateSessionRequestDto createSessionRequestDto);
      Task<GenericResponse> DeleteSession(Guid sessionId);
      Task<GenericResponse<IEnumerable<GetSessionResponseDto>>> GetSessionsByPredicate(Expression<Func<SessionEntity, bool>> predicate);
      Task<GenericResponse> UpdateSession(UpdateSessionRequestDto sessionRequestDto);
   }
}