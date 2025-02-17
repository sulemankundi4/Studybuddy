using Microsoft.EntityFrameworkCore;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Core.Dtos.Course;
using StudyBuddy.Core.Entities;
using StudyBuddy.Infrastructure.Contexts;

namespace StudyBuddy.Infrastructure.Repositories
{
   public class CourseRepository : ICourseRepository
   {
      private readonly StudyBuddyDbContext _context;

      public CourseRepository(StudyBuddyDbContext context)
      {
         _context = context;
      }

      public async Task<bool> CheckCourseExistenceAsync(string courseName, Guid termId)
      {
         return await _context.Courses
            .AsNoTracking().FirstOrDefaultAsync(x => EF.Functions.Like(x.Name, courseName) && x.TermId == termId) != null;
      }

      public async Task CreateCourseAsync(CourseEntity course)
      {
         await _context.Courses.AddAsync(course);
         await _context.SaveChangesAsync();
      }

      public async Task<CourseEntity?> GetCourseEntityByIdAsync(Guid courseId, Guid termId) =>
         await _context.Courses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == courseId && x.TermId == termId);

      public async Task UpdateCourseAsync(CourseEntity course)
      {
         _context.Update(course);
         await _context.SaveChangesAsync();
      }

      public async Task<IEnumerable<GetCourseResponseDto>> GetAllCoursesAsync(Guid termId)
      {
         var courses = await _context.Courses
             .AsNoTracking()
             .Where(x => x.TermId == termId)
             .ToListAsync();

         return courses.Select(course => course.Map()).ToList();
      }

      public async Task DeleteCourseAsync(Guid courseId, Guid termId)
      {
         using (var transaction = await _context.Database.BeginTransactionAsync())
         {
            try
            {
               await _context.Sessions.Where(s => s.CourseId == courseId).ExecuteDeleteAsync();
               await _context.Courses.Where(c => c.Id == courseId && c.TermId == termId).ExecuteDeleteAsync();
               await transaction.CommitAsync();
            }
            catch
            {
               await transaction.RollbackAsync();
               throw;
            }
         }
      }
   }
}
