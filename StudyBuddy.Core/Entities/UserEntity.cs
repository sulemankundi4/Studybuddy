namespace StudyBuddy.Core.Entities
{
   public class UserEntity
   {
      public Guid Id { get; set; }
      public string Name { get; set; } = null!;
      public string Email { get; set; } = null!;
      public string Password { get; set; } = null!;
      public string University { get; set; } = "";
   }
}