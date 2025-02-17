namespace StudyBuddy.Core.Entities
{
   public class ActivityEntity
   {
      public Guid Id { get; set; }
      public string Name { get; set; } = null!;
      public int TotalStudyTime { get; set; } = 0;
      public Guid TermId { get; set; }
      public TermEntity Term { get; set; } = null!;

      public virtual ICollection<SessionEntity> Sessions { get; set; } = [];
   }
}