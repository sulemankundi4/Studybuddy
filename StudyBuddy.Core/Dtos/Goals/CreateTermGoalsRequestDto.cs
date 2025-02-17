namespace StudyBuddy.Core.Dtos.Goals
{
   public sealed record CreateTermGoalsRequestDto(
      int WeekDayStudyTime,
      int WeekEndStudyTime,
      int StudyGoalTime
   );
}