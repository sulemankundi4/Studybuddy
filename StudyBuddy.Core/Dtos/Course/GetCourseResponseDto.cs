namespace StudyBuddy.Core.Dtos.Course
{
   public sealed record GetCourseResponseDto(
      Guid CourseId,
      string Name,
      DateOnly StartDate,
      DateOnly EndDate,
      int CourseGoalMinutes,
      string CourseNameColor
   );
}
