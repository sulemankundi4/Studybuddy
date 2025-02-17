using StudyBuddy.Core.BaseDtos;

namespace StudyBuddy.Core.Dtos.Course
{
   public class UpdateCourseRequestDto : BaseCoursesRequestDto
   {
      public Guid CourseId { get; set; }
   }
}