using Microsoft.EntityFrameworkCore;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Core.Dtos.Terms;
using StudyBuddy.Core.Entities;
using StudyBuddy.Infrastructure.Contexts;

namespace StudyBuddy.Infrastructure.Repositories
{
   public class TermRepository : ITermRepository
   {
      private readonly StudyBuddyDbContext _context;

      public TermRepository(StudyBuddyDbContext context)
      {
         _context = context;
      }

      public async Task CreateTermAsync(TermEntity termEntity)
      {
         await _context.Terms.AddAsync(termEntity);
         await _context.SaveChangesAsync();
      }

      public async Task DeleteTermAsync(Guid termId)
      {
         using (var transaction = await _context.Database.BeginTransactionAsync())
         {
            try
            {
               var term = await _context.Terms
                   .Include(t => t.Courses)
                   .Include(t => t.Goal)
                   .Include(t => t.Activities)
                   .Include(t => t.Sessions)
                   .FirstOrDefaultAsync(t => t.Id == termId);

               if (term != null)
               {
                  _context.Sessions.RemoveRange(term.Sessions);
                  _context.Courses.RemoveRange(term.Courses);
                  _context.Activities.RemoveRange(term.Activities);
                  _context.Goals.Remove(term.Goal);

                  _context.Terms.Remove(term);
                  await _context.SaveChangesAsync();
                  await transaction.CommitAsync();
               }
            }
            catch (Exception)
            {
               await transaction.RollbackAsync();
               throw;
            }
         }
      }

      public async Task<IEnumerable<GetTermResponseDto>> GetAllTerms(Guid userId)
      {
         var terms = await _context.Terms.AsNoTracking().Where(t => t.UserId == userId).ToListAsync();
         return terms.Select(term => term.Map()).ToList();
      }

      public async Task<TermEntity?> GetTermEntityByIdAsync(Guid termId) =>
       await _context.Terms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == termId);

      public async Task UpdateTermAsync(TermEntity termEntity)
      {
         _context.Terms.Update(termEntity);
         await _context.SaveChangesAsync();
      }
   }
}