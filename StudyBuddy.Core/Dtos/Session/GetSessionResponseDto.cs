namespace StudyBuddy.Core.Dtos.Session
{
   public sealed record GetSessionResponseDto(
      Guid Id,
      string Name,
      int SessionDuration,
      DateOnly SessionDate,
      string SessionNote,
      Guid TermId,
      Guid ActivityId,
      Guid CourseId,
      string CourseName,
      string ActivityName,
      string TermName
   );
}