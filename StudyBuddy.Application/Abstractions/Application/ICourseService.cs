using StudyBuddy.Core.Dtos.Course;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Abstractions.Application
{
   public interface ICourseService
   {
      Task<GenericResponse<GetCourseResponseDto>> GetCourseByIdAsync(Guid courseId, Guid termId);
      Task<GenericResponse> CreateCourseAsync(CreateCourseRequestDto createCourseRequestDto);
      Task<GenericResponse> UpdateCourseAsync(UpdateCourseRequestDto updateCourseRequestDto);
      Task<GenericResponse<IEnumerable<GetCourseResponseDto>>> GetAllCoursesAsync(Guid termId);
      Task<GenericResponse> DeleteCourseAsync(Guid courseId, Guid termId);
   }
}