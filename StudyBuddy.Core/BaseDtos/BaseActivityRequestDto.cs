namespace StudyBuddy.Core.BaseDtos
{
   public class BaseActivityRequestDto
   {
      public string Name { get; set; } = null!;
      public int ActivityProgressMinutes { get; set; }
      public Guid TermId { get; set; }
   }
}