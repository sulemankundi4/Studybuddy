using StudyBuddy.API.Middlewares;

namespace StudyBuddy.API
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddApiDI(this IServiceCollection services)
      {
         services.AddExceptionHandler<ExceptionHandlingMiddleware>();
         return services;
      }
   }
}