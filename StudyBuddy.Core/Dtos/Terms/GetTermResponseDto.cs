namespace StudyBuddy.Core.Dtos.Terms
{
   public sealed record GetTermResponseDto(
      Guid Id,
      string Name,
      DateOnly StartDate,
      DateOnly EndDate,
      int TermDuration,
      string TermNumber
   );
}