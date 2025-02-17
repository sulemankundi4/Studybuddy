using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Core.Dtos.Course;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class CourseController : ControllerBase
   {
      private readonly ICourseService _courseService;
      public CourseController(ICourseService courseService, ICourseRepository courseRepository)
      {
         _courseService = courseService;
      }

      [HttpPost("create")]
      public async Task<GenericResponse> CreateCourse([FromBody] CreateCourseRequestDto createCourseRequestDto) =>
         await _courseService.CreateCourseAsync(createCourseRequestDto);

      [HttpPut("update")]
      public async Task<GenericResponse> UpdateCourse([FromBody] UpdateCourseRequestDto updateCourseRequestDto) =>
         await _courseService.UpdateCourseAsync(updateCourseRequestDto);

      [HttpGet("/course/{courseId}")]
      public async Task<GenericResponse<GetCourseResponseDto>> GetCourseById(Guid courseId, Guid termId) =>
         await _courseService.GetCourseByIdAsync(courseId, termId);

      [HttpGet("/courses/all")]
      public async Task<GenericResponse<IEnumerable<GetCourseResponseDto>>> GetAllCourses(Guid termId) =>
         await _courseService.GetAllCoursesAsync(termId);
   }
}