using StudyBuddy.Core.Dtos.Auth;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Abstractions.Application
{
   public interface IAuthService
   {
      Task<GenericResponse<RegisterUserResponseDto>> RegisterUserAsync(RegisterUserRequestDto requestDto);
      Task<GenericResponse<LoginUserResponseDto>> LoginUserAsync(LoginUserRequestDto requestDto);
      Task<GenericResponse> VerifyOtpCodeAsync(OtpCodeRequestDto otpCode);
      Task<GenericResponse> SendOtpCodeAsync(SendOtpRequestDto sendOtpRequestDto);
      Task<GenericResponse> ForgetPasswordAsync(ForgetPasswordRequestDto forgetPasswordRequestDto);
   }


}