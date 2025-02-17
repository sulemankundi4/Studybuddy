namespace StudyBuddy.Core.BaseDtos
{
   public class BaseCoursesRequestDto
   {
      public string Name { get; set; } = null!;
      public DateOnly StartDate { get; set; }
      public DateOnly EndDate { get; set; }
      public int StudyGoal { get; set; }
      public string CourseNameColor { get; set; } = null!;
      public Guid TermId { get; set; }
   }
}