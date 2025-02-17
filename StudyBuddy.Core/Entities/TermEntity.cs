namespace StudyBuddy.Core.Entities
{
   public class TermEntity
   {
      public Guid Id { get; set; }
      public string Name { get; set; } = null!;
      public string TermNumber { get; set; } = null!;
      public DateOnly StartDate { get; set; }
      public DateOnly EndDate { get; set; }
      public int TermDuration { get; set; }
      public GoalEntity Goal { get; set; } = null!;
      public virtual ICollection<CourseEntity> Courses { get; set; } = [];
      public virtual ICollection<ActivityEntity> Activities { get; set; } = [];
      public virtual ICollection<SessionEntity> Sessions { get; set; } = [];
   }
}