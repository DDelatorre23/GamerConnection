using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using TermProject296N.Repository;
using Microsoft.EntityFrameworkCore;
using TermProject296N.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TermProject296N {
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IHostingEnvironment env) {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            //                   Configuration["Data:BookInfoDb:ConnectionString"]));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                                Configuration["Data:GamerConnection:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
                Configuration["Data:GamerConnectionIdentity:ConnectionString"]));
            
            services.AddIdentity<User, IdentityRole>(opts =>
            { opts.Cookies.ApplicationCookie.LoginPath = "/Authentication/Login"; })
                 .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddMvc();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<IGame, GameRepository>();
            //services.AddTransient<IBookRepository, BookRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
