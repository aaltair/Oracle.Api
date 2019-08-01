using oracle.api.Infrastructure.Contexts;
using oracle.api.Infrastructure.Interfaces;
using oracle.api.Infrastructure.Repositories;

namespace oracle.api.Infrastructure.UnitOfWorks
{
    public class UserUnitOfWork : UnitOfWork<UserDbContext>, IUserUnitOfWork
    {
        #region filed

        private UserRepository _userRepository;
        private AuthorRepository _authorRepository;
        private CourseRepository _courseRepository;

        #endregion

        public UserUnitOfWork(UserDbContext context)
        {
            _context = context;
        }

        #region initlitation
        public UserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_context));
        public AuthorRepository AuthorRepository => _authorRepository ?? (_authorRepository = new AuthorRepository(_context));
        public CourseRepository CourseRepository => _courseRepository ?? (_courseRepository = new CourseRepository(_context));

        #endregion
    }
}