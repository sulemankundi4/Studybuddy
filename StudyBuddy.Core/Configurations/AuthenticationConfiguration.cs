namespace StudyBuddy.Core.Configurations
{
   public class AuthenticationConfiguration
   {
      public required string SecretKey { get; set; }
      public required string Issuer { get; set; }
      public required string Audience { get; set; }
      public required TimeOnly TokenExpiryTimeFrame { get; set; }
   }
}