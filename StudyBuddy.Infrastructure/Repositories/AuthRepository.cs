using Microsoft.EntityFrameworkCore;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Core.Entities;
using StudyBuddy.Infrastructure.Contexts;

namespace StudyBuddy.Infrastructure.Repositories
{
   public class AuthRepository : IAuthRepository
   {
      private readonly StudyBuddyDbContext _dbContext;

      public AuthRepository(StudyBuddyDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      public async Task<UserEntity?> FindUserByEmailAsync(string email) =>
         await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);


      public async Task<UserEntity> CreateUserAsync(UserEntity user)
      {
         var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
         user.Password = hashedPassword;

         await _dbContext.Users.AddAsync(user);
         await _dbContext.SaveChangesAsync();
         return user;
      }

      public async Task InvalidateExistingOtpCodesAsync(string email)
      {
         var otpCode = await _dbContext.OTPCodes.FirstOrDefaultAsync(x => x.Email == email);
         if (otpCode != null)
         {
            _dbContext.OTPCodes.Remove(otpCode);
            await _dbContext.SaveChangesAsync();
         }
      }

      public async Task<string> SendOtpCodeAsync(OTPCodeEntity otpCodeEntity)
      {
         var otpCode = new Random().Next(100000, 999999).ToString();

         otpCodeEntity.OTPCode = otpCode;
         await _dbContext.OTPCodes.AddAsync(otpCodeEntity);

         await _dbContext.SaveChangesAsync();
         return otpCode;
      }

      public async Task<bool> VerifyOtpCodeAsync(OTPCodeEntity otpCodeEntity) =>
         await _dbContext.OTPCodes.AnyAsync(x => x.Email == otpCodeEntity.Email && x.OTPCode == otpCodeEntity.OTPCode && x.ExpireAt > DateTime.UtcNow);

      public async Task<bool> ResetPasswordAsync(UserEntity user, string newPassword)
      {
         _dbContext.Users.Attach(user);

         var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
         user.Password = hashedPassword;

         await _dbContext.SaveChangesAsync();
         return true;
      }
   }
}