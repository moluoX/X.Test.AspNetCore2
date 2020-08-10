using Autofac;
using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using X.Test.AspNetCore2.Service.Base;
using X.Test.AspNetCore2.Service.Impl.Base;

namespace X.Test.AspNetCore2.Service.Injector
{
    public class DbContextFactory<T> : IDbContextFactory<T> where T : DbContext
    {
        private ILifetimeScope _scope;
        ConnectionStringBuilder _connectionStringBuilder;
        public DbContextFactory(ILifetimeScope scope, ConnectionStringBuilder connectionStringBuilder)
        {
            _scope = scope;
            _connectionStringBuilder = connectionStringBuilder;
        }

        public T GetDbContext(DbContextReadOrWrite readOrWrite)
        {
            var connectionString = _connectionStringBuilder.Get<T>(readOrWrite);

            var opt = new DbContextOptionsBuilder<T>();
            opt.UseSqlServer(connectionString);
            
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(x => x.LogToStandardErrorThreshold = LogLevel.Trace); });
            opt.UseLoggerFactory(loggerFactory);

            return _scope.Resolve<T>(new ResolvedParameter((pi, ctx) => true, (pi, ctx) => opt.Options));
        }
    }
}
