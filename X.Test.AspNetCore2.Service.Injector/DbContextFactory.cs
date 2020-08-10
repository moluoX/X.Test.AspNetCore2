using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using X.Test.AspNetCore2.Service.Base;
using X.Test.AspNetCore2.Service.Impl.Base;

namespace X.Test.AspNetCore2.Service.Injector
{
    public class DbContextFactory<T> : IDbContextFactory<T> where T : DbContext
    {
        private ILifetimeScope _scope;
        public DbContextFactory(IServiceProvider serviceProvider)
        {
            _scope = serviceProvider.GetAutofacRoot();
        }

        public T GetDbContext(DbContextReadOrWrite readOrWrite)
        {
            return _scope.Resolve<T>();
        }
    }
}
