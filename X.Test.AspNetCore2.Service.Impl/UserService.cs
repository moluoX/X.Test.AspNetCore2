using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using X.Test.AspNetCore2.Model;

namespace X.Test.AspNetCore2.Service.Impl
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(SampleContext context) : base(context)
        {
        }
    }
}
