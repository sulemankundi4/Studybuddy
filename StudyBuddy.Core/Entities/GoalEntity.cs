namespace StudyBuddy.Core.Entities
{
   public class GoalEntity
   {
      public Guid Id { get; set; }
      public int WeekDayStudyTime { get; set; }
      public int WeekEndStudyTime { get; set; }
      public int StudyGoalTime { get; set; }
      public Guid TermId { get; set; }
      public virtual TermEntity Term { get; set; } = null!;
   }
}