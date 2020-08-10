using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace X.Test.AspNetCore2.Service.Base
{
    public interface IBaseService<T> where T : class, new()
    {
        Task<T> Get(int id, DbContextReadOrWrite readOrWrite = DbContextReadOrWrite.Read);
        Task<List<T>> ListAll(DbContextReadOrWrite readOrWrite = DbContextReadOrWrite.Read);
        Task Add(T m);
        Task Update(T m);
        Task Delete(int id);
    }
}
