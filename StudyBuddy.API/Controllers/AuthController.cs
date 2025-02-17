using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Application.Validators;
using StudyBuddy.Core.Constants;
using StudyBuddy.Core.Dtos.Auth;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class AuthController : ControllerBase
   {
      private readonly IAuthService _authService;
      public AuthController(IAuthService authService)
      {
         _authService = authService;
      }

      [HttpPost("register")]
      public async Task<GenericResponse<RegisterUserResponseDto>> RegisterUser([FromBody] RegisterUserRequestDto requestDto)
      {
         return await _authService.RegisterUserAsync(requestDto);
      }

      [HttpPost("login")]
      public async Task<GenericResponse<LoginUserResponseDto>> LoginUser([FromBody] LoginUserRequestDto requestDto)
      {
         return await _authService.LoginUserAsync(requestDto);
      }

      [HttpPost("verifyOtp")]
      public async Task<GenericResponse> VerifyOtpCode([FromBody] OtpCodeRequestDto otpCode)
      {
         return await _authService.VerifyOtpCodeAsync(otpCode);
      }

      [HttpPost("sendOtpCode")]
      public async Task<GenericResponse> SendOTPCode([FromBody] SendOtpRequestDto sendOtpRequestDto)
      {
         return await _authService.SendOtpCodeAsync(sendOtpRequestDto);
      }
      [HttpPost("forgetPassword")]
      public async Task<GenericResponse> ForgetPassword([FromBody] ForgetPasswordRequestDto requestDto)
      {
         return await _authService.ForgetPasswordAsync(requestDto);
      }
   }
}