using Microsoft.EntityFrameworkCore;
using StudyBuddy.Core.Entities;

namespace StudyBuddy.Infrastructure.Contexts
{
   public class StudyBuddyDbContext : DbContext
   {
      public StudyBuddyDbContext(DbContextOptions<StudyBuddyDbContext> options) : base(options)
      {

      }

      public DbSet<UserEntity> Users { get; set; }
      public DbSet<OTPCodeEntity> OTPCodes { get; set; }
      public DbSet<TermEntity> Terms { get; set; }
      public DbSet<GoalEntity> Goals { get; set; }
      public DbSet<CourseEntity> Courses { get; set; }
      public DbSet<SessionEntity> Sessions { get; set; }
      public DbSet<ActivityEntity> Activities { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudyBuddyDbContext).Assembly);
         base.OnModelCreating(modelBuilder);
      }
   }
}