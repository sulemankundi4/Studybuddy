using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Core.Configurations;

namespace StudyBuddy.Infrastructure.Services
{
   public class TokenService : ITokenService
   {
      private readonly AuthenticationConfiguration _authenticationConfiguration;
      private readonly SymmetricSecurityKey _key;

      public TokenService(IOptionsMonitor<AuthenticationConfiguration> authenticationConfiguration)
      {
         _authenticationConfiguration = authenticationConfiguration.CurrentValue;
         _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationConfiguration.SecretKey));
      }

      public string GenerateJWTToken(string email, string name, string id)
      {
         var accessClaims = new List<Claim>()
         {
            new (ClaimTypes.Email, email),
            new (ClaimTypes.Name, name),
            new (ClaimTypes.NameIdentifier,id),
         };

         var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

         var token = new JwtSecurityToken(
            issuer: _authenticationConfiguration.Issuer,
            audience: _authenticationConfiguration.Audience,
            claims: accessClaims,
            expires: DateTime.Now.Add(_authenticationConfiguration.TokenExpiryTimeFrame.ToTimeSpan()),
            signingCredentials: creds
         );

         return new JwtSecurityTokenHandler().WriteToken(token);
      }
   }
}
