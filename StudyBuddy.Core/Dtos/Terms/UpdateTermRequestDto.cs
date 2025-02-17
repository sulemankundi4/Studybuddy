using StudyBuddy.Core.BaseDtos;

namespace StudyBuddy.Core.Dtos.Terms
{
   public class UpdateTermRequestDto : BaseTermRequestDto
   {
      public Guid TermId { get; set; }
   }

}