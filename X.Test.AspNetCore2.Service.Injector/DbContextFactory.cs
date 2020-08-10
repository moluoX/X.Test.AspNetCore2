using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using X.Test.AspNetCore2.Service.Impl.Base;

namespace X.Test.AspNetCore2.Service.Injector
{
    public class DbContextFactory<T> : IDbContextFactory<T> where T : DbContext
    {
        public T GetDbContext(DbContextWriteOrRead writeOrRead)
        {
            throw new NotImplementedException();
        }
    }
}
