using System.Linq.Expressions;
using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Application.Validators.Sessions;
using StudyBuddy.Core.Constants;
using StudyBuddy.Core.Dtos.Session;
using StudyBuddy.Core.Entities;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Services
{
   public class SessionService : ISessionService
   {
      private readonly ISessionRepository _sessionRepository;
      public SessionService(ISessionRepository sessionRepository)
      {
         _sessionRepository = sessionRepository;
      }

      public async Task<GenericResponse> CreateSession(CreateSessionRequestDto createSessionRequestDto)
      {
         var Validators = new CreateSessionRequestDtoValidators();
         var validationResult = Validators.Validate(createSessionRequestDto);

         if (!validationResult.IsValid)
         {
            return validationResult.Errors.ToErrorResponse();
         }

         await _sessionRepository.CreateSessionAsync(createSessionRequestDto.Map());
         return GenericResponse.Success(ApiResponseMessages.SESSION_CREATED_SUCCESSFULLY, 200);
      }

      public async Task<GenericResponse<IEnumerable<GetSessionResponseDto>>> GetSessionsByPredicate(Expression<Func<SessionEntity, bool>> predicate)
      {
         var sessions = await _sessionRepository.GetSessionsByPredicateAsync(predicate);

         if (sessions == null || !sessions.Any())
         {
            return GenericResponse<IEnumerable<GetSessionResponseDto>>.Failure("No records found", 404);
         }

         return GenericResponse<IEnumerable<GetSessionResponseDto>>.Success(sessions, "Records found", 200);
      }

      public async Task<GenericResponse> UpdateSession(UpdateSessionRequestDto sessionRequestDto)
      {
         var validators = new UpdateSessionRequestDtoValidator();
         var validationResult = validators.Validate(sessionRequestDto);
         if (!validationResult.IsValid)
         {
            return validationResult.Errors.ToErrorResponse();
         }

         var sessionEntity = await _sessionRepository.GetSessionEntityByIdAsync(sessionRequestDto.SessionId);
         if (sessionEntity == null)
         {
            return GenericResponse.Failure(ApiResponseMessages.NO_RECORD_FOUND, 404);
         }

         sessionRequestDto.Map(sessionEntity);
         await _sessionRepository.UpdateSessionAsync(sessionEntity);

         return GenericResponse.Success(ApiResponseMessages.SESSION_UPDATED_SUCCESSFULLY, 200);
      }

      public async Task<GenericResponse> DeleteSession(Guid sessionId)
      {
         var sessionEntity = await _sessionRepository.GetSessionEntityByIdAsync(sessionId);
         if (sessionEntity == null)
         {
            return GenericResponse.Failure(ApiResponseMessages.NO_RECORD_FOUND, 404);
         }

         await _sessionRepository.DeleteSessionAsync(sessionEntity);
         return GenericResponse.Success(ApiResponseMessages.SESSION_DELETED_SUCCESSFULLY, 200);
      }
   }
}