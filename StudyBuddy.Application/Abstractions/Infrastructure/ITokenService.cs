namespace StudyBuddy.Application.Abstractions.Infrastructure
{
   public interface ITokenService
   {
      string GenerateJWTToken(string email, string name, string id);
   }
}