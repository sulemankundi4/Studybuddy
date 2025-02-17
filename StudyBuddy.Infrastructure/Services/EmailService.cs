using FluentEmail.Core;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Core.Configurations;

namespace StudyBuddy.Infrastructure.Services
{
   public class EmailService : IEmailService
   {
      private readonly IFluentEmail _fluentEmail;

      public EmailService(IFluentEmail fluentEmail)
      {
         _fluentEmail = fluentEmail;
      }

      public async Task SendEmailAsync(EmailConfiguration emailConfiguration)
      {
         await _fluentEmail.To(emailConfiguration.ToAddress)
            .Subject(emailConfiguration.Subject)
            .Body(emailConfiguration.Body)
            .SendAsync();
      }
   }
}