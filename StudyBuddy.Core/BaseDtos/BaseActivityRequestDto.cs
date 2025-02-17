namespace StudyBuddy.Core.BaseDtos
{
   public class BaseActivityRequestDto
   {
      public string Name { get; set; } = null!;
      public int TotalStudyTime { get; set; }
      public Guid TermId { get; set; }
   }
}