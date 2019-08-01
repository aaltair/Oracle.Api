using System.Collections.Generic;
using oracle.api.Dtos.Course;

namespace oracle.api.Dtos.Author
{
    public class AuthorCourseDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorNameEn { get; set; }
        public ICollection<CourseDto> Courses { set; get; }
    }
}