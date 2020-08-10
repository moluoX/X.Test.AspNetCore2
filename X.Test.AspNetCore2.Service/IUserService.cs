using System;
using System.Threading.Tasks;
using X.Test.AspNetCore2.Model;
using X.Test.AspNetCore2.Service.Base;

namespace X.Test.AspNetCore2.Service
{
    public interface IUserService : IBaseService<User>
    {
    }
}
