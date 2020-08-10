using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using X.Test.AspNetCore2.Model;

namespace X.Test.AspNetCore2.Service.Impl
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(SchoolContext context) : base(context)
        {
        }

        public async Task<Student> GetWithCourse(int id)
        {
            return await _dbSet.Include(x => x.Enrollments).ThenInclude(x => x.Course).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
