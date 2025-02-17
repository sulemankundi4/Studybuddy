using StudyBuddy.Application.Abstractions.Application;
using StudyBuddy.Application.Abstractions.Infrastructure;
using StudyBuddy.Application.Mapping;
using StudyBuddy.Application.Validators.Courses;
using StudyBuddy.Core.Constants;
using StudyBuddy.Core.Dtos.Course;
using StudyBuddy.Core.GenericResponse;

namespace StudyBuddy.Application.Services
{
   public class CourseService : ICourseService
   {
      private readonly ICourseRepository _courseRepository;
      public CourseService(ICourseRepository courseRepository)
      {
         _courseRepository = courseRepository;
      }
      public async Task<GenericResponse> CreateCourseAsync(CreateCourseRequestDto createCourseRequestDto)
      {
         var validator = new CreateCourseRequestDtoValidator();
         var validationResult = validator.Validate(createCourseRequestDto);

         if (!validationResult.IsValid)
         {
            return validationResult.Errors.ToErrorResponse();
         }

         var courseEntity = createCourseRequestDto.Map();
         var courseExists = await _courseRepository.CheckCourseExistenceAsync(courseEntity.Name, courseEntity.TermId);

         if (courseExists)
         {
            return GenericResponse.Failure(ApiResponseMessages.COURSE_NAME_ALREADY_EXISTS_CHOOSE_ANY_OTHER, 409);
         }

         await _courseRepository.CreateCourseAsync(courseEntity);
         return GenericResponse.Success(ApiResponseMessages.COURSE_CREATED, 200);
      }
      public async Task<GenericResponse> UpdateCourseAsync(UpdateCourseRequestDto updateCourseRequestDto)
      {
         var validator = new UpdateCourseRequestDtoValidator();
         var validationResult = validator.Validate(updateCourseRequestDto);

         if (!validationResult.IsValid)
         {
            return validationResult.Errors.ToErrorResponse();
         }

         var courseEntity = await _courseRepository.GetCourseEntityByIdAsync(updateCourseRequestDto.CourseId, updateCourseRequestDto.TermId);
         if (courseEntity == null)
         {
            return GenericResponse.Failure(ApiResponseMessages.COURSE_NOT_FOUND, 404);
         }

         updateCourseRequestDto.Map(courseEntity);
         await _courseRepository.UpdateCourseAsync(courseEntity);
         return GenericResponse.Success(ApiResponseMessages.COURSE_UPDATED, 200);
      }

      public async Task<GenericResponse<GetCourseResponseDto>> GetCourseByIdAsync(Guid courseId, Guid termId)
      {
         var course = await _courseRepository.GetCourseEntityByIdAsync(courseId, termId);
         if (course == null)
         {
            return GenericResponse<GetCourseResponseDto>.Failure(ApiResponseMessages.COURSE_NOT_FOUND, 404);
         }
         var responseDto = course.Map();
         return GenericResponse<GetCourseResponseDto>.Success(responseDto, ApiResponseMessages.RECORD_FOUND, 200);
      }

      public async Task<GenericResponse<IEnumerable<GetCourseResponseDto>>> GetAllCoursesAsync(Guid termId)
      {
         var courses = await _courseRepository.GetAllCoursesAsync(termId);
         if (courses == null || !courses.Any())
         {
            return GenericResponse<IEnumerable<GetCourseResponseDto>>.Failure(ApiResponseMessages.NO_RECORDS_FOUND, 404);
         }

         return GenericResponse<IEnumerable<GetCourseResponseDto>>.Success(courses, ApiResponseMessages.RECORD_FOUND, 200);
      }
   }
}