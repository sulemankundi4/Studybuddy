using StudyBuddy.Core.BaseDtos;

namespace StudyBuddy.Core.Dtos.Activities
{
   public class UpdateActivityRequestDto : BaseActivityRequestDto
   {
      public Guid ActivityId { get; set; }
   };
}