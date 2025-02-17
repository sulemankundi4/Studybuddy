using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Infrastructure.Contexts;
using StudyBuddy.Infrastructure.Repositories;
using StudyBuddy.Infrastructure.Services;
using FluentEmail.Smtp;
using System.Net;
using System.Net.Mail;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using StudyBuddy.Core.Configurations;

namespace StudyBuddy.Infrastructure
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
      {

         var emailSettings = configuration.GetSection("EmailSettings");
         var defaultFromEmail = emailSettings["DefaultFromEmail"];
         var smtpUsername = emailSettings["SMTPSetting:Username"];
         var smtpPassword = emailSettings["SMTPSetting:Password"];
         var host = emailSettings["SMTPSetting:Host"];
         var port = emailSettings.GetValue<int>("SMTPSetting:Port");

         services.AddFluentEmail(defaultFromEmail)
            .AddSmtpSender(new SmtpClient(host)
            {
               Port = port,
               Credentials = new NetworkCredential(smtpUsername, smtpPassword),
               EnableSsl = true,
            });

         services.AddDbContext<StudyBuddyDbContext>(options =>
         {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
         });

         services.AddScoped<IAuthRepository, AuthRepository>();
         services.AddScoped<IEmailService, EmailService>();
         services.AddScoped<ITokenService, TokenService>();
         services.AddScoped<ITermRepository, TermRepository>();
         services.AddScoped<ICourseRepository, CourseRepository>();
         services.AddScoped<ISessionRepository, SessionRepository>();
         services.AddScoped<IActivityRepository, ActivityRepository>();

         var tokenValidationParameters = new TokenValidationParameters()
         {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = configuration["AuthenticationConfiguration:Issuer"],
            ValidAudience = configuration["AuthenticationConfiguration:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthenticationConfiguration:SecretKey"] ?? string.Empty)),
            ClockSkew = TimeSpan.Zero
         };

         services.AddAuthentication(options =>
         {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

         }).AddJwtBearer(jwt =>
         {
            jwt.TokenValidationParameters = tokenValidationParameters;
         });

         services.Configure<AuthenticationConfiguration>(configuration.GetSection("AuthenticationConfiguration"));

         services.AddSingleton(tokenValidationParameters);
         return services;
      }
   }
}