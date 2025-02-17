using Microsoft.EntityFrameworkCore;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Core.Dtos.Activities;
using StudyBuddy.Core.Entities;
using StudyBuddy.Core.GenericResponse;
using StudyBuddy.Infrastructure.Contexts;

namespace StudyBuddy.Infrastructure.Repositories
{
   public class ActivityRepository : IActivityRepository
   {
      private readonly StudyBuddyDbContext _context;
      public ActivityRepository(StudyBuddyDbContext context)
      {
         _context = context;
      }

      public async Task<bool> CheckActivityExistsAsync(string activityName, Guid termId)
      {
         return await _context.Activities
        .AsNoTracking().FirstOrDefaultAsync(x => EF.Functions.Like(x.Name, activityName) && x.TermId == termId) != null;
      }

      public async Task CreateActivityAsync(ActivityEntity activity)
      {
         await _context.Activities.AddAsync(activity);
         await _context.SaveChangesAsync();
      }

      public async Task DeleteActivityAsync(Guid activityId, Guid termId)
      {
         using (var transaction = await _context.Database.BeginTransactionAsync())
         {
            try
            {
               var activity = await _context.Activities.Include(a => a.Sessions).FirstOrDefaultAsync(a => a.Id == activityId && a.TermId == termId);
               if (activity != null)
               {
                  foreach (var session in activity.Sessions)
                  {
                     session.ActivityId = null;
                  }

                  _context.Activities.Remove(activity);
                  await _context.SaveChangesAsync();
                  await transaction.CommitAsync();
               }
            }
            catch
            {
               await transaction.RollbackAsync();
               throw;
            }
         }
      }

      public async Task<ActivityEntity?> GetActivityByIdAsync(Guid activityId, Guid termId) =>
         await _context.Activities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == activityId && x.TermId == termId);

      public async Task<IEnumerable<GetActivityResponseDto>> GetAllActivitiesAsync(Guid termId)
      {
         var activities = await _context.Activities.AsNoTracking().Where(x => x.TermId == termId).ToListAsync();
         return activities.Select(activity => activity.Map()).ToList();
      }

      public async Task UpdateActivityAsync(ActivityEntity activity)
      {
         _context.Activities.Update(activity);
         await _context.SaveChangesAsync();
      }
   }
}