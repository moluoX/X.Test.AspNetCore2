using System.Threading.Tasks;
using X.Test.AspNetCore2.Model;

namespace X.Test.AspNetCore2.Service
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<Student> GetWithCourse(int id);
    }
}
