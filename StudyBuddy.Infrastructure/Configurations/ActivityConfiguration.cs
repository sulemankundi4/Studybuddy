namespace StudyBuddy.Infrastructure.Configurations
{
   using Microsoft.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore.Metadata.Builders;
   using StudyBuddy.Core.Entities;

   public class ActivityConfiguration : IEntityTypeConfiguration<ActivityEntity>
   {
      public void Configure(EntityTypeBuilder<ActivityEntity> builder)
      {
         builder.HasMany(s => s.Sessions).WithOne(a => a.Activity).HasForeignKey(s => s.ActivityId).OnDelete(DeleteBehavior.NoAction);
      }
   }
}