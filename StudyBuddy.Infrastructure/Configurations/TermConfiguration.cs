using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyBuddy.Core.Entities;

namespace StudyBuddy.Infrastructure.Configurations
{
   public class TermConfiguration : IEntityTypeConfiguration<TermEntity>
   {
      public void Configure(EntityTypeBuilder<TermEntity> builder)
      {
         builder.HasOne(t => t.Goal).WithOne(t => t.Term).HasForeignKey<GoalEntity>(g => g.TermId).OnDelete(DeleteBehavior.NoAction);
         builder.HasMany(c => c.Courses).WithOne(t => t.Term).HasForeignKey(c => c.TermId).OnDelete(DeleteBehavior.NoAction);
         builder.HasMany(a => a.Activities).WithOne(t => t.Term).HasForeignKey(a => a.TermId).OnDelete(DeleteBehavior.NoAction);
         builder.HasMany(s => s.Sessions).WithOne(t => t.Term).HasForeignKey(s => s.TermId).OnDelete(DeleteBehavior.NoAction);
      }
   }
}