namespace StudyBuddy.Core.Entities
{
   public class OTPCodeEntity
   {
      public Guid Id { get; set; }
      public string Email { get; set; } = null!;
      public string OTPCode { get; set; } = null!;
      public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
      public string OTPUseCase { get; set; } = null!;
      public DateTime ExpireAt { get; set; } = DateTime.UtcNow.AddMinutes(5);
   }
}