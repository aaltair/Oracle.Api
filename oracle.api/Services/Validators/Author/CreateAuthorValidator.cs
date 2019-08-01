using FluentValidation;
using oracle.api.Dtos.Author;

namespace oracle.api.Services.Validators.Author
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorValidator()
        {
            RuleFor(w => w.AuthorName).NotNull().NotEmpty();
            RuleFor(w => w.AuthorNameEn).NotNull().NotEmpty();
        }
    }
}