namespace StudyBuddy.Core.BaseDtos
{
   public class BaseTermRequestDto
   {
      public string Name { get; set; } = null!;
      public string TermNumber { get; set; } = null!;
      public DateOnly StartDate { get; set; }
      public DateOnly EndDate { get; set; }
      public int TermDuration { get; set; }
   }
}