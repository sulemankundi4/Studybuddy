namespace StudyBuddy.Core.BaseDtos
{
   public class BaseSessionRequestDto
   {
      public string Name { get; set; } = null!;
      public int SessionDuration { get; set; }
      public DateOnly SessionDate { get; set; }
      public string? SessionNote { get; set; }
      public Guid CourseId { get; set; }
      public Guid TermId { get; set; }
      public Guid ActivityId { get; set; }
   }
}
