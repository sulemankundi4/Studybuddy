using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Core.Dtos.Terms;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]

   public class TermController : ControllerBase
   {
      private readonly ITermService _termService;

      public TermController(ITermService termService)
      {
         _termService = termService;
      }

      [HttpGet("all/{userId}")]
      public async Task<GenericResponse<IEnumerable<GetTermResponseDto>>> GetTerms(Guid userId) =>
         await _termService.GetTermsAsync(userId);

      [HttpPost("new")]
      public async Task<GenericResponse> CreateTerm([FromBody] CreateTermRequestDto createTermRequestDto) =>
         await _termService.CreateTermAsync(createTermRequestDto);

      [HttpPut("update")]
      public async Task<GenericResponse> UpdateTerm([FromBody] UpdateTermRequestDto updateTermRequestDto) =>
         await _termService.UpdateTermAsync(updateTermRequestDto);

      [HttpGet("{termId}")]
      public async Task<GenericResponse<GetTermResponseDto>> GetTermById(Guid termId) =>
         await _termService.GetTermByIdAsync(termId);

      [HttpDelete("delete/{termId}")]
      public async Task<GenericResponse> DeleteTerm(Guid termId) =>
         await _termService.DeleteTermAsync(termId);
   }
}