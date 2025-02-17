using StudyBuddy.Core.BaseDtos;

namespace StudyBuddy.Core.Dtos.Session
{
   public class UpdateSessionRequestDto : BaseSessionRequestDto
   {
      public Guid SessionId { get; set; }
   };
}