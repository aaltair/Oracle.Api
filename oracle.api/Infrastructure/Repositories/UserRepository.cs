using oracle.api.Entities.User;
using oracle.api.Infrastructure.Abstracts;
using oracle.api.Infrastructure.Contexts;

namespace oracle.api.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }
    }
}