using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Application.Validators;
using StudyBuddy.Core.Configurations;
using StudyBuddy.Core.Constants;
using StudyBuddy.Core.Dtos.Auth;
using StudyBuddy.Core.Entities;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Services
{
   public class AuthService : IAuthService
   {
      private readonly IAuthRepository _authRepository;
      private readonly IEmailService _emailService;
      private readonly ITokenService _tokenService;
      public AuthService(IAuthRepository authRepository, IEmailService emailService, ITokenService tokenService)
      {
         _authRepository = authRepository;
         _emailService = emailService;
         _tokenService = tokenService;
      }

      public async Task<GenericResponse<RegisterUserResponseDto>> RegisterUserAsync(RegisterUserRequestDto requestDto)
      {
         var validator = new RegisterUserRequestDtoValidator();
         var validationResult = validator.Validate(requestDto);

         if (!validationResult.IsValid)
         {
            return validationResult.Errors.ToErrorResponse<RegisterUserResponseDto>();
         }

         var checkExistingUser = await _authRepository.FindUserByEmailAsync(requestDto.Email);
         if (checkExistingUser is not null)
         {
            return GenericResponse<RegisterUserResponseDto>.Failure(ApiResponseMessages.USER_ALREADY_EXISTS, 404);
         }

         if (requestDto.Password != requestDto.ConfirmPassword)
         {
            return GenericResponse<RegisterUserResponseDto>.Failure(ApiResponseMessages.PASSWORD_DOES_NOT_MATCH, 404);
         }

         if (string.IsNullOrWhiteSpace(requestDto.OtpCode))
         {
            await _authRepository.InvalidateExistingOtpCodesAsync(requestDto.Email);
            string OTPCode = await _authRepository.SendOtpCodeAsync(new OTPCodeEntity
            {
               Email = requestDto.Email,
               OTPUseCase = OtpUseCases.REGISTER_OTP
            });

            await _emailService.SendEmailAsync(new EmailConfiguration(
            requestDto.Email,
            "OTP Code",
            $"Your OTP Code is {OTPCode}"
         ));

            return GenericResponse<RegisterUserResponseDto>.Failure(ApiResponseMessages.OTP_CODE_SENT_SUCCESSFULLY, 200);
         }

         if (!await _authRepository.VerifyOtpCodeAsync(new OTPCodeEntity
         {
            Email = requestDto.Email,
            OTPCode = requestDto.OtpCode,
            OTPUseCase = OtpUseCases.REGISTER_OTP
         }))
         {
            return GenericResponse<RegisterUserResponseDto>.Failure(ApiResponseMessages.INVALID_OTP_CODE_OR_EXPIRED, 404);
         }

         var userEntity = requestDto.Map();
         var user = await _authRepository.CreateUserAsync(userEntity);

         var token = _tokenService.GenerateJWTToken(user.Email, user.Name, user.Id.ToString());

         var response = new RegisterUserResponseDto(
            requestDto.Name,
            requestDto.Email,
            Token: token
            );

         return GenericResponse<RegisterUserResponseDto>.Success(response, ApiResponseMessages.USER_REGISTERED_SUCCESSFULLY, 200);
      }

      public async Task<GenericResponse<LoginUserResponseDto>> LoginUserAsync(LoginUserRequestDto requestDto)
      {
         var validator = new LoginUserRequestDtoValidator();
         var validationResults = validator.Validate(requestDto);
         if (!validationResults.IsValid)
         {
            return validationResults.Errors.ToErrorResponse<LoginUserResponseDto>();
         }

         var user = await _authRepository.FindUserByEmailAsync(requestDto.Email);
         if (user is null)
         {
            return GenericResponse<LoginUserResponseDto>.Failure(ApiResponseMessages.INVALID_EMAIL_OR_PASSWORD, 401);
         }

         if (!BCrypt.Net.BCrypt.Verify(requestDto.Password, user.Password))
         {
            return GenericResponse<LoginUserResponseDto>.Failure(ApiResponseMessages.INVALID_EMAIL_OR_PASSWORD, 401);
         }

         var token = _tokenService.GenerateJWTToken(user.Email, user.Name, user.Id.ToString());

         var response = new LoginUserResponseDto(
            user.Email,
            user.Name,
            token
         );

         return GenericResponse<LoginUserResponseDto>.Success(response, $"{ApiResponseMessages.WELCOME_BACK_MESSAGE} {response.Name}", 200);
      }

      public async Task<GenericResponse> VerifyOtpCodeAsync(OtpCodeRequestDto otpCodeRequestDto)
      {
         var isOTPCodeValid = await _authRepository.VerifyOtpCodeAsync(otpCodeRequestDto.Map());
         if (!isOTPCodeValid)
         {
            return GenericResponse.Failure(ApiResponseMessages.INVALID_OTP_CODE_OR_EXPIRED, 404);
         }

         return GenericResponse.Success(ApiResponseMessages.EMAIL_HAS_BEEN_VERIFIED, 200);
      }

      public async Task<GenericResponse> SendOtpCodeAsync(SendOtpRequestDto sendOtpRequestDto)
      {
         var otpCode = await _authRepository.SendOtpCodeAsync(new OTPCodeEntity
         {
            Email = sendOtpRequestDto.Email,
            OTPUseCase = sendOtpRequestDto.OtpUseCase
         });

         await _emailService.SendEmailAsync(new EmailConfiguration(
              sendOtpRequestDto.Email,
              $"OTP Code for {sendOtpRequestDto.OtpUseCase}",
              $"Your OTP Code is {otpCode}"
           ));

         return GenericResponse.Success(ApiResponseMessages.OTP_CODE_SENT_SUCCESSFULLY, 200);
      }

      public async Task<GenericResponse> ForgetPasswordAsync(ForgetPasswordRequestDto forgetPasswordRequestDto)
      {
         var user = await _authRepository.FindUserByEmailAsync(forgetPasswordRequestDto.Email);
         if (user is null)
         {
            return GenericResponse.Failure(ApiResponseMessages.USER_NOT_FOUND, 404);
         }

         if (string.IsNullOrWhiteSpace(forgetPasswordRequestDto.OtpCode))
         {
            await _authRepository.InvalidateExistingOtpCodesAsync(forgetPasswordRequestDto.Email);
            var otpCode = await _authRepository.SendOtpCodeAsync(new OTPCodeEntity
            {
               Email = forgetPasswordRequestDto.Email,
               OTPUseCase = OtpUseCases.FORGOT_OTP
            });

            await _emailService.SendEmailAsync(new EmailConfiguration(
                 forgetPasswordRequestDto.Email,
                 $"OTP Code for {OtpUseCases.FORGOT_OTP}",
                 $"Your OTP Code is {otpCode}"
              ));

            return GenericResponse.Success(ApiResponseMessages.OTP_CODE_SENT_SUCCESSFULLY, 200);
         }

         var isValidOTP = await _authRepository.VerifyOtpCodeAsync(forgetPasswordRequestDto.Map());
         if (!isValidOTP)
         {
            return GenericResponse.Failure(ApiResponseMessages.INVALID_OTP_CODE_OR_EXPIRED, 404);
         }

         if (!await _authRepository.ResetPasswordAsync(user, forgetPasswordRequestDto.NewPassword))
         {
            return GenericResponse.Failure(ApiResponseMessages.FAILED_TO_RESET_PASSWORD, 500);
         }

         return GenericResponse.Success(ApiResponseMessages.PASSWORD_RESET_SUCCESSFULLY, 200);
      }
   }
}