using Autofac;
using System;
using System.Linq;
using X.Test.AspNetCore2.Service.Impl.Base;

namespace X.Test.AspNetCore2.Service.Injector
{
    public class AutofacConfigurer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionStringBuilder>().SingleInstance();

            builder.RegisterType<DbContextFactory<SampleContext>>().As<IDbContextFactory<SampleContext>>().SingleInstance();
            builder.RegisterType<DbContextFactory<SchoolContext>>().As<IDbContextFactory<SchoolContext>>().SingleInstance();

            builder.RegisterType<SampleContext>();
            builder.RegisterType<SchoolContext>();

            var assembly = typeof(SampleContext).Assembly;
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
        }
    }
}
