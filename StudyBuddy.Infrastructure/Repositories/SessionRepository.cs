using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Core.Dtos.Session;
using StudyBuddy.Core.Entities;
using StudyBuddy.Infrastructure.Contexts;

namespace StudyBuddy.Infrastructure.Repositories
{
   public class SessionRepository : ISessionRepository
   {

      private readonly StudyBuddyDbContext _context;
      public SessionRepository(StudyBuddyDbContext context)
      {
         _context = context;
      }

      public async Task CreateSessionAsync(SessionEntity sessionEntity)
      {
         using (var transaction = await _context.Database.BeginTransactionAsync())
         {
            try
            {

               var term = await _context.Terms.Include(t => t.Goal).FirstOrDefaultAsync(t => t.Id == sessionEntity.TermId);
               term!.Goal.TermProgressMinutes += sessionEntity.SessionDuration;

               var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == sessionEntity.CourseId);
               course!.CourseProgressMinutes += sessionEntity.SessionDuration;

               if (sessionEntity.ActivityId != null)
               {
                  var activity = await _context.Activities.Where(a => a.Id == sessionEntity.ActivityId).FirstOrDefaultAsync();
                  activity!.ActivityProgressMinutes += sessionEntity.SessionDuration;
               }

               await _context.Sessions.AddAsync(sessionEntity);
               await _context.SaveChangesAsync();
               await transaction.CommitAsync();
            }
            catch
            {
               await transaction.RollbackAsync();
               throw;
            }
         }
      }

      public async Task<IEnumerable<GetSessionResponseDto>> GetSessionsByPredicateAsync(Expression<Func<SessionEntity, bool>> predicate)
      {
         return await _context.Sessions
            .AsNoTracking()
            .Where(predicate)
            .Include(s => s.Term)
            .Include(s => s.Course)
            .Include(s => s.Activity)
            .Select(session => session.Map())
            .ToListAsync();
      }

      public async Task<SessionEntity?> GetSessionEntityByIdAsync(Guid sessionId) =>
       await _context.Sessions.FindAsync(sessionId);


      public async Task UpdateSessionAsync(SessionEntity sessionEntity)
      {
         _context.Sessions.Update(sessionEntity);
         await _context.SaveChangesAsync();
      }

      public async Task DeleteSessionAsync(SessionEntity sessionEntity)
      {
         _context.Sessions.Remove(sessionEntity);
         await _context.SaveChangesAsync();
      }
   }
}