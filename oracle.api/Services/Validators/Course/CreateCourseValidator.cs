using FluentValidation;
using oracle.api.Dtos.Course;

namespace oracle.api.Services.Validators.Course
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseValidator()
        {
            RuleFor(w => w.CourseName).NotNull().NotEmpty();
            RuleFor(w => w.CourseNameEn).NotNull().NotEmpty();
            RuleFor(w => w.CourseCategory).NotNull().NotEmpty();
            RuleFor(w => w.CourseCategoryEn).NotNull().NotEmpty();
            RuleFor(w => w.AuthorId).NotNull().NotEmpty();
        }
    }
}