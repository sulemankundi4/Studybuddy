using Microsoft.Extensions.DependencyInjection;

namespace StudyBuddy.Core
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddCoreDI(this IServiceCollection services)
      {
         return services;
      }
   }
}