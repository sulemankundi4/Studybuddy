
using StudyBuddy.Core.Dtos.Activities;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Abstractions.Application
{
   public interface IActivityService
   {
      Task<GenericResponse> CreateActivityAsync(CreateActivityRequestDto request);
      Task<GenericResponse> DeleteActivityAsync(Guid activityId, Guid termId);
      Task<GenericResponse<GetActivityResponseDto>> GetActivityByIdAsync(Guid activityId, Guid termId);
      Task<GenericResponse<IEnumerable<GetActivityResponseDto>>> GetAllActivitiesAsync(Guid termId);
      Task<GenericResponse> UpdateActivityAsync(UpdateActivityRequestDto request);
   }
}