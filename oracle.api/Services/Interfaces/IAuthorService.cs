using oracle.api.Dtos;
using oracle.api.Dtos.Author;

namespace oracle.api.Services.Interfaces
{
    public interface IAuthorService
    {
        PagedResultsDto<AuthorDto> GetAllAuthors(int pageIndex, int pageSize);
        PagedResultsDto<AuthorCourseDto> GetAllAuthorsWithCourses(int pageIndex, int pageSize);
        AuthorCourseDto GetAuthorById(int id);
        AuthorDto CreateAuthor(CreateAuthorDto createAuthor, string currentUserId);
        AuthorDto UpdateAuthor(AuthorDto author, string currentUserId);
        AuthorDto DeleteAuthor(int id, string currentUserId);
    }
}