using System.Linq.Expressions;
using StudyBuddy.Core.Dtos.Session;
using StudyBuddy.Core.Entities;

namespace StudyBuddy.Application.Abstractions.Infrastructure
{
   public interface ISessionRepository
   {
      Task CreateSessionAsync(SessionEntity sessionEntity);
      Task<IEnumerable<GetSessionResponseDto>> GetSessionsByPredicateAsync(Expression<Func<SessionEntity, bool>> predicate);
      Task<SessionEntity?> GetSessionEntityByIdAsync(Guid sessionId);
      Task UpdateSessionAsync(SessionEntity sessionEntity);
      Task DeleteSessionAsync(SessionEntity sessionEntity);
   }
}