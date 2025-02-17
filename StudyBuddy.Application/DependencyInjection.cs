using Microsoft.Extensions.DependencyInjection;
using StudyBuddy.Application.Validators;
using FluentValidation;
using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Application.Services;

namespace StudyBuddy.Application
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddApplicationDI(this IServiceCollection services)
      {
         services.AddValidatorsFromAssemblyContaining<RegisterUserRequestDtoValidator>();
         services.AddScoped<IAuthService, AuthService>();
         services.AddScoped<ITermService, TermServices>();
         services.AddScoped<ICourseService, CourseService>();
         services.AddScoped<ISessionService, SessionService>();
         services.AddScoped<IActivityService, ActivityService>();

         return services;
      }
   }
}

