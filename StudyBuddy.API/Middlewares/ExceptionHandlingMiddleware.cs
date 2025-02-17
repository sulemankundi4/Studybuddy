using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using StudyBuddy.Core.Constants;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.API.Middlewares
{
   public class ExceptionHandlingMiddleware : IExceptionHandler
   {
      private readonly IWebHostEnvironment _env;

      public ExceptionHandlingMiddleware(IWebHostEnvironment env)
      {
         _env = env;
      }


      public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
      {
         httpContext.Response.ContentType = "application/json";

         short statusCode = exception switch
         {
            ArgumentNullException => (short)HttpStatusCode.BadRequest,
            ArgumentException => (short)HttpStatusCode.BadRequest,
            NullReferenceException => (short)HttpStatusCode.InternalServerError,
            UnauthorizedAccessException => (short)HttpStatusCode.Unauthorized,
            _ => (short)HttpStatusCode.InternalServerError
         };

         httpContext.Response.StatusCode = statusCode;

         var payload = exception.InnerException != null ? exception.InnerException.ToString() : string.Empty;

         var response = _env.IsDevelopment() || _env.IsProduction() ? GenericResponse<string>.Failure(payload, exception.Message, statusCode) : GenericResponse<string>.Failure(ApiResponseMessages.SOMETHING_WENT_WRONG, statusCode);

         JsonSerializerOptions options = new()
         {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
         };

         var json = JsonSerializer.Serialize(response, options);

         await httpContext.Response.WriteAsync(json, cancellationToken: cancellationToken);

         return true;
      }
   }
}