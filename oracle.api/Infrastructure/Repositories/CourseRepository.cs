using oracle.api.Entities.Course;
using oracle.api.Infrastructure.Abstracts;
using oracle.api.Infrastructure.Contexts;

namespace oracle.api.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        private readonly UserDbContext _context;

        public CourseRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }
    }
}