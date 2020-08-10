using System;
using System.Diagnostics;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using X.Test.AspNetCore2.Service.Injector;

namespace X.Test.AspNetCore2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession();
            services.AddDistributedRedisCache(x =>
            {
                x.InstanceName = Configuration["Redis:InstanceName"];
                x.Configuration = Configuration["Redis:Configuration"];
            });

            //services.AddDbContext<SampleContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("SampleConnection")));
            //services.AddDbContext<SchoolContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("SchoolConnection")));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacConfigurer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use((next) =>
            {
                return async c =>
                {
                    Console.WriteLine($"{DateTime.Now} req");
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    await next(c);
                    sw.Stop();
                    Console.WriteLine($"{DateTime.Now} res {sw.ElapsedMilliseconds}ms");
                };
            });

            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
