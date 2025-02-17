namespace StudyBuddy.Core.Dtos.Auth
{
   public sealed record OtpCodeRequestDto(string Email, string OtpCode, string OtpUseCase);
}