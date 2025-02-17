using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Core.Dtos.Session;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class SessionController : ControllerBase
   {
      private readonly ISessionService _sessionService;

      public SessionController(ISessionService sessionService)
      {
         _sessionService = sessionService;
      }

      [HttpPost("new")]
      public async Task<GenericResponse> CreateSession([FromBody] CreateSessionRequestDto sessionRequestDto) =>
          await _sessionService.CreateSession(sessionRequestDto);


      [HttpGet("term/all")]
      public async Task<GenericResponse<IEnumerable<GetSessionResponseDto>>> GetAllSessionsForTerm(Guid termId) =>
         await _sessionService.GetSessionsByPredicate(s => s.TermId == termId);


      [HttpGet("course/all")]
      public async Task<GenericResponse<IEnumerable<GetSessionResponseDto>>> GetAllSessionsForCourse(Guid courseId) =>
        await _sessionService.GetSessionsByPredicate(s => s.CourseId == courseId);


      [HttpGet("activity/all")]
      public async Task<GenericResponse<IEnumerable<GetSessionResponseDto>>> GetAllSessionsForActivity(Guid activityid) =>
        await _sessionService.GetSessionsByPredicate(s => s.ActivityId == activityid);

      [HttpPut("update")]
      public async Task<GenericResponse> UpdateSession([FromBody] UpdateSessionRequestDto sessionRequestDto) =>
         await _sessionService.UpdateSession(sessionRequestDto);

      [HttpDelete("delete/{sessionId}")]
      public async Task<GenericResponse> DeleteSession(Guid sessionId) =>
         await _sessionService.DeleteSession(sessionId);
   }


}