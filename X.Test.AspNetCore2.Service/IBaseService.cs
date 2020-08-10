using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace X.Test.AspNetCore2.Service
{
    public interface IBaseService<T> where T : class, new()
    {
        Task<T> Get(int id);
        Task<List<T>> ListAll();
        Task Add(T m);
        Task Update(T m);
        Task Delete(int id);
    }
}
