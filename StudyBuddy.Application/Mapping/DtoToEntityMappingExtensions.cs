using StudyBuddy.Core.Dtos.Activities;
using StudyBuddy.Core.Dtos.Auth;
using StudyBuddy.Core.Dtos.Course;
using StudyBuddy.Core.Dtos.Goals;
using StudyBuddy.Core.Dtos.Session;
using StudyBuddy.Core.Dtos.Terms;
using StudyBuddy.Core.Entities;

namespace StudyBuddy.Application.Mapping
{
   public static class DtoToEntityMappingExtensions
   {

      public static void Map(this UpdateActivityRequestDto updateActivityRequestDto, ActivityEntity activityEntity)
      {
         activityEntity.Name = updateActivityRequestDto.Name;
         activityEntity.TotalStudyTime = updateActivityRequestDto.TotalStudyTime;
         activityEntity.TermId = updateActivityRequestDto.TermId;
      }

      public static void Map(this UpdateTermRequestDto updateTermRequestDto, TermEntity termEntity)
      {
         termEntity.Name = updateTermRequestDto.Name;
         termEntity.StartDate = updateTermRequestDto.StartDate;
         termEntity.EndDate = updateTermRequestDto.EndDate;
         termEntity.TermDuration = updateTermRequestDto.TermDuration;
         termEntity.TermNumber = updateTermRequestDto.TermNumber;
      }

      public static void Map(this UpdateCourseRequestDto updateCourseRequestDto, CourseEntity courseEntity)
      {
         courseEntity.Name = updateCourseRequestDto.Name;
         courseEntity.StudyGoal = updateCourseRequestDto.StudyGoal;
         courseEntity.StartDate = updateCourseRequestDto.StartDate;
         courseEntity.EndDate = updateCourseRequestDto.EndDate;
         courseEntity.CourseNameColor = updateCourseRequestDto.CourseNameColor;
      }

      public static void Map(this UpdateSessionRequestDto updateSessionRequestDto, SessionEntity sessionEntity)
      {
         sessionEntity.Name = updateSessionRequestDto.Name;
         sessionEntity.SessionDuration = updateSessionRequestDto.SessionDuration;
         sessionEntity.SessionDate = updateSessionRequestDto.SessionDate;
         sessionEntity.SessionNote = updateSessionRequestDto.SessionNote;
         sessionEntity.CourseId = updateSessionRequestDto.CourseId;
         sessionEntity.TermId = updateSessionRequestDto.TermId;
         sessionEntity.ActivityId = updateSessionRequestDto.ActivityId;
      }

      public static UserEntity Map(this RegisterUserRequestDto requestDto)
      {
         return new UserEntity
         {
            Email = requestDto.Email,
            Password = requestDto.Password,
            Name = requestDto.Name,
         };
      }

      public static OTPCodeEntity Map(this OtpCodeRequestDto otpCodeRequestDto)
      {
         return new OTPCodeEntity
         {
            Email = otpCodeRequestDto.Email,
            OTPCode = otpCodeRequestDto.OtpCode
         };
      }

      public static OTPCodeEntity Map(this ForgetPasswordRequestDto forgetPasswordRequestDto)
      {
         return new OTPCodeEntity
         {
            Email = forgetPasswordRequestDto.Email,
            OTPCode = forgetPasswordRequestDto.OtpCode
         };
      }

      public static TermEntity Map(this CreateTermRequestDto createTermRequestDto)
      {
         return new TermEntity
         {
            Name = createTermRequestDto.Name,
            StartDate = createTermRequestDto.StartDate,
            EndDate = createTermRequestDto.EndDate,
            TermDuration = createTermRequestDto.TermDuration,
            TermNumber = createTermRequestDto.TermNumber,
            Goal = new GoalEntity
            {
               StudyGoalTime = createTermRequestDto.Goals.StudyGoalTime,
               WeekDayStudyTime = createTermRequestDto.Goals.WeekDayStudyTime,
               WeekEndStudyTime = createTermRequestDto.Goals.WeekEndStudyTime
            }
         };
      }



      // COURSES MAPPING STARTS FROM HERE#
      public static CourseEntity Map(this CreateCourseRequestDto createCourseRequestDto)
      {
         return new CourseEntity
         {
            Name = createCourseRequestDto.Name,
            StudyGoal = createCourseRequestDto.StudyGoal,
            StartDate = createCourseRequestDto.StartDate,
            EndDate = createCourseRequestDto.EndDate,
            CourseNameColor = createCourseRequestDto.CourseNameColor,
            TermId = createCourseRequestDto.TermId
         };
      }


      // Sessions mapping starts from here
      public static SessionEntity Map(this CreateSessionRequestDto createSessionRequestDto)
      {
         return new SessionEntity
         {
            Name = createSessionRequestDto.Name,
            SessionDuration = createSessionRequestDto.SessionDuration,
            SessionDate = createSessionRequestDto.SessionDate,
            SessionNote = createSessionRequestDto.SessionNote,
            CourseId = createSessionRequestDto.CourseId,
            TermId = createSessionRequestDto.TermId,
            ActivityId = createSessionRequestDto.ActivityId
         };
      }


      // Activities mapping starts from here
      public static ActivityEntity Map(this CreateActivityRequestDto createActivityRequestDto)
      {
         return new ActivityEntity
         {
            Name = createActivityRequestDto.Name,
            TermId = createActivityRequestDto.TermId
         };
      }



   }

}