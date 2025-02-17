namespace StudyBuddy.Core.Dtos.Auth
{
   public sealed record ForgetPasswordRequestDto(string Email, string OtpCode, string NewPassword);
}