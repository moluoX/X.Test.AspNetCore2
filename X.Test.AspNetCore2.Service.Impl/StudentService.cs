using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using X.Test.AspNetCore2.Model;
using X.Test.AspNetCore2.Service.Base;
using X.Test.AspNetCore2.Service.Impl.Base;

namespace X.Test.AspNetCore2.Service.Impl
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(IDbContextFactory<SampleContext> contextFactory) : base(contextFactory)
        {
        }

        public async Task<Student> GetWithCourse(int id)
        {
            return await Set(DbContextReadOrWrite.Read).Include(x => x.Enrollments).ThenInclude(x => x.Course).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
