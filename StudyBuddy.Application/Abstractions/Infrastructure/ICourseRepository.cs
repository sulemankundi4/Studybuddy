using StudyBuddy.Core.Dtos.Course;
using StudyBuddy.Core.Entities;

namespace StudyBuddy.Application.Abstractions.Infrastructure
{
   public interface ICourseRepository
   {
      Task<bool> CheckCourseExistenceAsync(string courseName, Guid termId);
      Task CreateCourseAsync(CourseEntity course);
      Task UpdateCourseAsync(CourseEntity course);
      Task<CourseEntity?> GetCourseEntityByIdAsync(Guid courseId, Guid termId);
      Task<IEnumerable<GetCourseResponseDto>> GetAllCoursesAsync(Guid termId);
      Task DeleteCourseAsync(Guid courseId, Guid termId);
   }
}