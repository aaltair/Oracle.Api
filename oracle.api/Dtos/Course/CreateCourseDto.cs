namespace oracle.api.Dtos.Course
{
    public class CreateCourseDto
    {
        public string CourseName { get; set; }
        public string CourseNameEn { get; set; }
        public string CourseCategory { get; set; }
        public string CourseCategoryEn { get; set; }
        public int AuthorId { get; set; }
    }
}