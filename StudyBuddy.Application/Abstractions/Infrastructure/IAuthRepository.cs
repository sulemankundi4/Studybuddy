using StudyBuddy.Core.Dtos.Auth;
using StudyBuddy.Core.Entities;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Abstractions.Infrastructure
{
   public interface IAuthRepository
   {
      Task<UserEntity?> FindUserByEmailAsync(string email);
      Task<UserEntity> CreateUserAsync(UserEntity user);
      Task InvalidateExistingOtpCodesAsync(string email);
      Task<string> SendOtpCodeAsync(OTPCodeEntity otpCodeEntity);
      Task<bool> VerifyOtpCodeAsync(OTPCodeEntity otpCodeEntity);
      Task<bool> ResetPasswordAsync(UserEntity user, string newPassword);
   }
}