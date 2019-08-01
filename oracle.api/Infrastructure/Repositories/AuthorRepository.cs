using oracle.api.Entities.Auther;
using oracle.api.Infrastructure.Abstracts;
using oracle.api.Infrastructure.Contexts;

namespace oracle.api.Infrastructure.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        private readonly UserDbContext _context;

        public AuthorRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

    }
}