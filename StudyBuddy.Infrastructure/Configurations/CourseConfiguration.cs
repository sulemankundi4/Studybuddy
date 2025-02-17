using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyBuddy.Core.Entities;

namespace StudyBuddy.Infrastructure.Configurations
{
   public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
   {
      public void Configure(EntityTypeBuilder<CourseEntity> builder)
      {
         builder.HasMany(s => s.Sessions)
                .WithOne(c => c.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
      }
   }
}