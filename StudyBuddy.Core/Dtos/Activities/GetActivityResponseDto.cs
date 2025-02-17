namespace StudyBuddy.Core.Dtos.Activities
{
   public sealed record GetActivityResponseDto(
      Guid Id,
      string Name,
      int TotalStudyTime,
      Guid TermId
   );
}