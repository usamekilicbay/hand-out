using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Services.Abstract;
using BusinessLogicLayer.Services.Concrete;
using DataAccessLayer;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using hand_out.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace hand_out
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/User/SignIn");
                _.AccessDeniedPath = new PathString("/User/SignIn");
                _.ExpireTimeSpan = TimeSpan.FromDays(2);
                _.SlidingExpiration = true;
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddCors(options => options.AddDefaultPolicy(policy =>
                             policy.AllowAnyHeader()
                                   .AllowAnyMethod()
                                   .AllowCredentials()
                                   .SetIsOriginAllowed(origin => true)));

            services.AddSignalR();

            services.AddSingleton(p => GetUnitOfWorkInstance(services));
            services.AddSingleton(p => GetProductServiceInstance(services));
            services.AddSingleton(p => GetCategoryServiceInstance(services));
            services.AddSingleton(p => GetUserServiceInstance(services));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // My operations
            Sidekick.NET.Constant.Path.SetPaths(env.WebRootPath);

            app.UseStaticFiles();
            app.UseCors();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                  name: "admin",
                  areaName: "AdminPanel",
                  pattern: "admin/{controller=User}/{action=Create}/{id?}"
                  );

                endpoints.MapControllerRoute(
                    name: "defaultArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                endpoints.MapHub<ChatHub>("/chathub");
            });
        }

        private static IUnitOfWork GetUnitOfWorkInstance(IServiceCollection services)
        {
            IServiceProvider provider = services.BuildServiceProvider();

            return new UnitOfWork(
            provider.GetService<ApplicationDbContext>(),
            provider.GetService<IMapper>(),
            provider.GetService<UserManager<User>>(),
            provider.GetService<SignInManager<User>>(),
            provider.GetService<IHttpContextAccessor>());
        }

        private static IProductService GetProductServiceInstance(IServiceCollection services)
        {
            IServiceProvider provider = services.BuildServiceProvider();

            return new ProductService(
            provider.GetService<ApplicationDbContext>(),
            provider.GetService<IMapper>(),
            provider.GetService<IUnitOfWork>());
        }

        private static ICategoryService GetCategoryServiceInstance(IServiceCollection services)
        {
            IServiceProvider provider = services.BuildServiceProvider();

            return new CategoryService(
            provider.GetService<ApplicationDbContext>(),
            provider.GetService<IMapper>(),
            provider.GetService<IUnitOfWork>());
        }

        private static IUserService GetUserServiceInstance(IServiceCollection services)
        {
            IServiceProvider provider = services.BuildServiceProvider();

            return new UserService(
            provider.GetService<ApplicationDbContext>(),
            provider.GetService<IMapper>(),
            provider.GetService<UserManager<User>>(),
            provider.GetService<SignInManager<User>>(),
            provider.GetService<IHttpContextAccessor>(),
            provider.GetService<IUnitOfWork>());
        }
    }
}