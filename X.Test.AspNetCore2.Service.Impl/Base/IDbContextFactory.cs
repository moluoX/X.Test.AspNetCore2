using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using X.Test.AspNetCore2.Service.Base;

namespace X.Test.AspNetCore2.Service.Impl.Base
{
    public interface IDbContextFactory<out T> where T : DbContext
    {
        T GetDbContext(DbContextReadOrWrite readOrWrite);
    }
}
