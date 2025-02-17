using StudyBuddy.Core.Dtos.Activities;
using StudyBuddy.Core.Entities;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Abstractions.Infrastructure
{
   public interface IActivityRepository
   {
      Task CreateActivityAsync(ActivityEntity activity);
      Task<bool> CheckActivityExistsAsync(string activityName, Guid termId);
      Task<IEnumerable<GetActivityResponseDto>> GetAllActivitiesAsync(Guid termId);
      Task<ActivityEntity?> GetActivityByIdAsync(Guid activityId, Guid termId);
      Task UpdateActivityAsync(ActivityEntity activity);
      Task DeleteActivityAsync(Guid activityId, Guid termId);
   }
}