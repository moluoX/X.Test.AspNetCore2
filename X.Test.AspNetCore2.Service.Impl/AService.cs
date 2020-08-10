
namespace X.Test.AspNetCore2.Service.Impl
{
    //[Intercept(typeof(SampleInterceptor))]
    public class AService : IAService
    {
        public string Do(string a)
        {
            return a;
        }
    }

    //public class SampleInterceptor : IInterceptor
    //{
    //    public void Intercept(IInvocation invocation)
    //    {
    //        Console.WriteLine($"[SampleInterceptor]pre Method {invocation.Method}");
    //        Console.WriteLine($"[SampleInterceptor]pre Arguments {string.Join(", ", invocation.Arguments)}");
    //        invocation.Proceed();
    //        Console.WriteLine($"[SampleInterceptor]post Method {invocation.Method}");
    //    }
    //}

    //public class AOPSample : Autofac.Module
    //{
    //    protected override void Load(ContainerBuilder builder)
    //    {
    //        builder.Register(x => new SampleInterceptor());
    //        //builder.RegisterType<AService>().As<IAService>().EnableInterfaceInterceptors();
    //        //builder.RegisterType<UserService>().As<IUserService>().EnableInterfaceInterceptors();

    //        //var service = Assembly.Load(File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "X.Test.AspNetCore2.Service.Impl.dll")));
    //        //builder.RegisterAssemblyTypes(service).Where(x=>x.Name.EndsWith("Service")).AsImplementedInterfaces();

    //        //builder.RegisterAssemblyTypes(Assembly.LoadFile(Path.Combine(AppContext.BaseDirectory, "X.Test.AspNetCore2.Service.Impl.dll"))).AsImplementedInterfaces();

    //        //var dataAccess = Assembly.GetExecutingAssembly();
    //        //builder.RegisterAssemblyTypes(dataAccess).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();

    //    }
    //}
}
