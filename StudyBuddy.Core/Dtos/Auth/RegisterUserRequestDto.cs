namespace StudyBuddy.Core.Dtos.Auth
{
   public sealed record RegisterUserRequestDto(
   string Name,
   string Email,
   string Password,
   string ConfirmPassword,
   string OtpCode
   );
}