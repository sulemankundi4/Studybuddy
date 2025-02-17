namespace StudyBuddy.Core.Dtos.Auth
{
   public sealed record RegisterUserResponseDto(
      string Name,
      string Email,
      string Token
   );
}