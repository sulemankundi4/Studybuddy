using StudyBuddy.Core.Configurations;

namespace StudyBuddy.Application.Abstractions.Infrastructure
{
   public interface IEmailService
   {
      Task SendEmailAsync(EmailConfiguration emailConfiguration);

   }
}