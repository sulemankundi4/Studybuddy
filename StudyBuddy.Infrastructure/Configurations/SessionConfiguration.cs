// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using StudyBuddy.Core.Entities;

// namespace StudyBuddy.Infrastructure.Configurations
// {
//    public class SessionConfiguration : IEntityTypeConfiguration<SessionEntity>
//    {
//       public void Configure(EntityTypeBuilder<SessionEntity> builder)
//       {
//          builder.HasOne(s => s.Activity)
//                 .WithMany(a => a.Sessions)
//                 .HasForeignKey(s => s.ActivityId)
//                 .OnDelete(DeleteBehavior.SetNull);

//          builder.HasOne(s => s.Course)
//                 .WithMany(c => c.Sessions)
//                 .HasForeignKey(s => s.CourseId);

//          builder.HasOne(s => s.Term)
//                 .WithMany(t => t.Sessions)
//                 .HasForeignKey(s => s.TermId);
//       }
//    }
// }