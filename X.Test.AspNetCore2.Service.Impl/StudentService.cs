using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.Test.AspNetCore2.Model;
using X.Test.AspNetCore2.Service.Base;
using X.Test.AspNetCore2.Service.Impl.Base;
using System.Linq;

namespace X.Test.AspNetCore2.Service.Impl
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(IDbContextFactory<SchoolContext> contextFactory) : base(contextFactory)
        {
        }

        public async Task<Student> GetWithCourse(int id)
        {
            return await Set(DbContextReadOrWrite.Read).Include(x => x.Enrollments).ThenInclude(x => x.Course).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IList<Student>> ListByCondition(Student condition)
        {
            var q = from x in Set(DbContextReadOrWrite.Read).Include(x => x.Enrollments).ThenInclude(x => x.Course).AsNoTracking() select x;
            if (!string.IsNullOrEmpty(condition.FirstMidName))
            {
                q = q.Where(x => x.FirstMidName.Contains(condition.FirstMidName));
            }
            if (!string.IsNullOrEmpty(condition.LastName))
            {
                q = q.Where(x => x.LastName.Contains(condition.LastName));
            }
            return await q.ToListAsync();
        }
    }
}
