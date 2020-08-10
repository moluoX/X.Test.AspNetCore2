using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace X.Test.AspNetCore2.Service.Impl.Base
{
    public interface IDbContextFactory<out T> where T : DbContext
    {
        T GetDbContext(DbContextWriteOrRead writeOrRead);
    }

    public enum DbContextWriteOrRead
    {
        Write = 0,
        Read = 1
    }
}
