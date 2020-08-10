using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using X.Test.AspNetCore2.Service.Impl.Base;

namespace X.Test.AspNetCore2.Service.Injector
{
    public class AutofacConfigurer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();
                var opt = new DbContextOptionsBuilder<SampleContext>();
                opt.UseSqlServer(config.GetConnectionString("SampleConnection"));
                var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(x => x.LogToStandardErrorThreshold = LogLevel.Trace); });
                opt.UseLoggerFactory(loggerFactory);
                return new SampleContext(opt.Options);
            });
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();
                var opt = new DbContextOptionsBuilder<SchoolContext>();
                opt.UseSqlServer(config.GetConnectionString("SchoolConnection"));
                var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(x => x.LogToStandardErrorThreshold = LogLevel.Trace); });
                opt.UseLoggerFactory(loggerFactory);
                return new SchoolContext(opt.Options);
            });

            builder.RegisterType<DbContextFactory<SampleContext>>().As<IDbContextFactory<SampleContext>>().SingleInstance();
            builder.RegisterType<DbContextFactory<SchoolContext>>().As<IDbContextFactory<SchoolContext>>().SingleInstance();

            //var service = Assembly.Load(File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "X.Test.AspNetCore2.Service.Impl.dll")));
            //builder.RegisterAssemblyTypes(service).Where(x=>x.Name.EndsWith("Service")).AsImplementedInterfaces();

            var assembly = typeof(SampleContext).Assembly;
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
        }
    }
}
