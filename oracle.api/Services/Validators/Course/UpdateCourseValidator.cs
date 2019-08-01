using FluentValidation;
using oracle.api.Dtos.Course;

namespace oracle.api.Services.Validators.Course
{
    public class UpdateCourseValidator : AbstractValidator<CourseDto>
    {
        public UpdateCourseValidator()
        {
            RuleFor(w => w.CourseId).NotNull().NotEmpty();
            RuleFor(w => w.CourseName).NotNull().NotEmpty();
            RuleFor(w => w.CourseNameEn).NotNull().NotEmpty();
            RuleFor(w => w.CourseCategory).NotNull().NotEmpty();
            RuleFor(w => w.CourseCategoryEn).NotNull().NotEmpty();
            RuleFor(w => w.AuthorId).NotNull().NotEmpty();
        }
    }
}