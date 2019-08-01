using FluentValidation;
using oracle.api.Dtos.Author;

namespace oracle.api.Services.Validators.Author
{
    public class UpdateAuthorValidator : AbstractValidator<AuthorDto>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(w => w.AuthorId).NotNull().NotEmpty();
            RuleFor(w => w.AuthorName).NotNull().NotEmpty();
            RuleFor(w => w.AuthorNameEn).NotNull().NotEmpty();
        }
    }
}