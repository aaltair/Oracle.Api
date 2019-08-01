using oracle.api.Dtos;
using oracle.api.Dtos.Course;

namespace oracle.api.Services.Interfaces
{
    public interface ICourseService
    {
        PagedResultsDto<CourseDto> GetAllCourse(int pageIndex, int pageSize);
        PagedResultsDto<CourseAuthorDto> GetAllCourseWithAuthor(int pageIndex, int pageSize);
        CourseAuthorDto GetCourseById(int id);
        CourseDto CreateCourse(CreateCourseDto createCourseDto, string currentUserId);
        CourseDto UpdateCourse(CourseDto courseDto, string currentUserId);
        CourseDto DeleteCourse(int id, string currentUserId);
    }
}