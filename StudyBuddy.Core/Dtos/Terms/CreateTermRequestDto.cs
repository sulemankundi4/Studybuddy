using StudyBuddy.Core.BaseDtos;
using StudyBuddy.Core.Dtos.Goals;

namespace StudyBuddy.Core.Dtos.Terms
{
   public class CreateTermRequestDto : BaseTermRequestDto
   {
      public CreateTermGoalsRequestDto Goals { get; set; } = null!;
   }
}