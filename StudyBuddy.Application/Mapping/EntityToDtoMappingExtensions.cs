using StudyBuddy.Core.Dtos.Activities;
using StudyBuddy.Core.Dtos.Course;
using StudyBuddy.Core.Dtos.Session;
using StudyBuddy.Core.Dtos.Terms;
using StudyBuddy.Core.Entities;

namespace StudyBuddy.Application.Mapping
{
   public static class EntityToDtoMappingExtensions
   {
      public static GetCourseResponseDto Map(this CourseEntity course)
      {
         return new GetCourseResponseDto
         (
            course.Id,
            course.Name,
            course.StartDate,
            course.EndDate,
            course.CourseGoalMinutes,
            course.CourseNameColor
         );
      }

      public static GetTermResponseDto Map(this TermEntity term)
      {
         return new GetTermResponseDto
         (
            term.Id,
            term.UserId,
            term.Name,
            term.StartDate,
            term.EndDate,
            term.TermDuration,
            term.TermNumber
         );
      }

      public static GetActivityResponseDto Map(this ActivityEntity activity)
      {
         return new GetActivityResponseDto
         (
            activity.Id,
            activity.Name,
            activity.ActivityProgressMinutes,
            activity.TermId
         );
      }

      public static GetSessionResponseDto Map(this SessionEntity session)
      {
         return new GetSessionResponseDto
          (
             session.Id,
             session.Name,
             session.SessionDuration,
             session.SessionDate,
             session.SessionNote ?? string.Empty,
             session.TermId,
             session.ActivityId ?? Guid.Empty,
             session.CourseId,
             session.Course.Name,
             session.Activity.Name,
             session.Term.Name
          );
      }


   }
}