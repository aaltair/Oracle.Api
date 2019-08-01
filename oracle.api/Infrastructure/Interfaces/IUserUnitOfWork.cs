using oracle.api.Infrastructure.Contexts;
using oracle.api.Infrastructure.Repositories;

namespace oracle.api.Infrastructure.Interfaces
{
    public interface IUserUnitOfWork : IUnitOfWork<UserDbContext>
    {
        UserRepository UserRepository { get; }
        AuthorRepository AuthorRepository { get; }
        CourseRepository CourseRepository { get; }
    }
}