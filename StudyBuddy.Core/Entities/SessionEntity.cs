namespace StudyBuddy.Core.Entities
{
   public class SessionEntity
   {
      public Guid Id { get; set; }
      public string Name { get; set; } = null!;
      public int SessionDuration { get; set; }
      public DateOnly SessionDate { get; set; }
      public string? SessionNote { get; set; }
      public Guid CourseId { get; set; }
      public CourseEntity Course { get; set; } = null!;
      public Guid TermId { get; set; }
      public TermEntity Term { get; set; } = null!;
      public Guid? ActivityId { get; set; }
      public ActivityEntity Activity { get; set; } = null!;
   }
}