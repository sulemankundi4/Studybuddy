namespace StudyBuddy.Core.Entities
{
   public class CourseEntity
   {
      public Guid Id { get; set; }
      public string Name { get; set; } = null!;
      public int StudyGoal { get; set; }
      public DateOnly StartDate { get; set; }
      public DateOnly EndDate { get; set; }
      public string CourseNameColor { get; set; } = null!;
      public Guid TermId { get; set; }
      public virtual TermEntity Term { get; set; } = null!;
      public virtual ICollection<SessionEntity> Sessions { get; set; } = [];
   }
}