using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Application.Validators.Activity;
using StudyBuddy.Core.Constants;
using StudyBuddy.Core.Dtos.Activities;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Services
{
   public class ActivityService : IActivityService
   {
      private readonly IActivityRepository _activityRepository;
      public ActivityService(IActivityRepository activityRepository)
      {
         _activityRepository = activityRepository;
      }
      public async Task<GenericResponse> CreateActivityAsync(CreateActivityRequestDto requestDto)
      {
         var validator = new CreateActivityRequestDtoValidator();
         var validationResult = validator.Validate(requestDto);
         if (!validationResult.IsValid)
         {
            return validationResult.Errors.ToErrorResponse();
         }

         var activityExists = await _activityRepository.CheckActivityExistsAsync(requestDto.Name, requestDto.TermId);
         if (activityExists)
         {
            return GenericResponse.Failure(ApiResponseMessages.ACTIVITY_ALREADY_EXISTS, 400);
         }

         await _activityRepository.CreateActivityAsync(requestDto.Map());
         return GenericResponse.Success(ApiResponseMessages.ACTIVITY_CREATED, 200);
      }
      public async Task<GenericResponse<IEnumerable<GetActivityResponseDto>>> GetAllActivitiesAsync(Guid termId)
      {
         var activities = await _activityRepository.GetAllActivitiesAsync(termId);
         if (activities == null || !activities.Any())
         {
            return GenericResponse<IEnumerable<GetActivityResponseDto>>.Failure(ApiResponseMessages.NO_RECORD_FOUND, 404);
         }

         return GenericResponse<IEnumerable<GetActivityResponseDto>>.Success(activities, ApiResponseMessages.RECORD_FOUND, 200);
      }

      public async Task<GenericResponse<GetActivityResponseDto>> GetActivityByIdAsync(Guid activityId, Guid termId)
      {
         var activity = await _activityRepository.GetActivityByIdAsync(activityId, termId);
         if (activity == null)
         {
            return GenericResponse<GetActivityResponseDto>.Failure(ApiResponseMessages.NO_RECORD_FOUND, 404);
         }

         var repsonseDto = activity.Map();
         return GenericResponse<GetActivityResponseDto>.Success(repsonseDto, ApiResponseMessages.RECORD_FOUND, 200);
      }

      public async Task<GenericResponse> UpdateActivityAsync(UpdateActivityRequestDto requestDto)
      {
         var validataor = new UpdateActivityRequestDtoValidator();
         var validationResult = validataor.Validate(requestDto);

         if (!validationResult.IsValid)
         {
            return validationResult.Errors.ToErrorResponse();
         }

         var activity = await _activityRepository.GetActivityByIdAsync(requestDto.ActivityId, requestDto.TermId);
         if (activity == null)
         {
            return GenericResponse.Failure(ApiResponseMessages.NO_RECORD_FOUND, 404);
         }
         requestDto.Map(activity);
         await _activityRepository.UpdateActivityAsync(activity);

         return GenericResponse.Success(ApiResponseMessages.ACTIVITY_UPDATED, 200);
      }

      public async Task<GenericResponse> DeleteActivityAsync(Guid activityId, Guid termId)
      {
         var activity = await _activityRepository.GetActivityByIdAsync(activityId, termId);

         if (activity != null)
         {
            await _activityRepository.DeleteActivityAsync(activityId, termId);
            return GenericResponse.Success(ApiResponseMessages.ACTIVITY_DELETED_SUCCESSFULLY, 200);
         }

         return GenericResponse.Failure(ApiResponseMessages.NO_RECORD_FOUND, 404);
      }
   }
}