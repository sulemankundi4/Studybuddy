using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Core.Dtos.Activities;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ActivityController : ControllerBase
   {
      private readonly IActivityService _activityService;
      public ActivityController(IActivityService activityService)
      {
         _activityService = activityService;
      }

      [HttpPost("new")]
      public async Task<GenericResponse> CreateActivityAsync([FromBody] CreateActivityRequestDto request) =>
         await _activityService.CreateActivityAsync(request);

      [HttpGet("all")]
      public async Task<GenericResponse<IEnumerable<GetActivityResponseDto>>> GetAllActivitiesAsync(Guid termId) =>
         await _activityService.GetAllActivitiesAsync(termId);

      [HttpGet("{activityId}")]
      public async Task<GenericResponse<GetActivityResponseDto>> GetActivityAsync(Guid activityId, Guid termId) =>
         await _activityService.GetActivityByIdAsync(activityId, termId);

      [HttpPut("update")]
      public async Task<GenericResponse> UpdateActivityAsync([FromBody] UpdateActivityRequestDto request) =>
         await _activityService.UpdateActivityAsync(request);

      [HttpDelete("delete/{activityId}")]
      public async Task<GenericResponse> DeleteActivityAsync(Guid activityId, Guid termId) =>
         await _activityService.DeleteActivityAsync(activityId, termId);
   }
}