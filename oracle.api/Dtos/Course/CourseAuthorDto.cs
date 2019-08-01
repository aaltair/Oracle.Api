using oracle.api.Dtos.Author;

namespace oracle.api.Dtos.Course
{
    public class CourseAuthorDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseNameEn { get; set; }
        public string CourseCategory { get; set; }
        public string CourseCategoryEn { get; set; }
        public int AuthorId { get; set; }
        public AuthorDto Author { set; get; }
    }
}