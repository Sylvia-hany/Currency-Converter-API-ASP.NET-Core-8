using AssR1WebApp.Filtters;
using AssR1WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AssR1WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. //ay 7&8
            //Built in service  already regiater
            //Built in Service nee dto register
            //builder.Services.AddControllersWithViews(option => {
            // option.Filters.Add(new HandelErrorAttribute());
            //});
            builder.Services.AddControllersWithViews();

            //REgister contstruction(options)
            builder.Services.AddDbContext<ITIContext>(optionbuilder =>
            {
                optionbuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            //register Session Service
            builder.Services.AddSession(options => { 
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            })
                .AddEntityFrameworkStores<ITIContext>();

            
            
            
            //Custom service and need register
            builder.Services.AddScoped<IEmployeeReposiotry,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentReposiotry,DepartmentRepository>();
            builder.Services.AddScoped<IService, Service>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.  //midleware
            #region Custom Pipline
            //inline Midddlware
            //app.Use(async(httpContext,next) => {
            //    //httpContext.Request.metho
            //    await httpContext.Response.WriteAsync("1) Middleware 1 \n");
            //    //invoke next middleware
            //    await next.Invoke();//<--
            //    //Execute
            //    await httpContext.Response.WriteAsync("1-1) Middleware 1-1 \n");


            //});
            //app.Use(async (httpContext, next) => {
            //    //httpContext.Request.metho
            //    await httpContext.Response.WriteAsync("2) Middleware 2 \n");
            //    //invoke next middleware
            //    await next.Invoke();//<--
            //    //Execute
            //    await httpContext.Response.WriteAsync("2-2) Middleware 2-2 \n");

            //});

            //app.Run(async(httpcontxt) => {
            //    await httpcontxt.Response.WriteAsync("3) Terminate \n");
            //});

            #endregion



            #region Built in PipleLine
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();//Security "Routing tbale" mapping
            
            app.UseSession();

            app.UseAuthorization();



            #region CustomRoute "Naming Convention Route |Route Constraint"
            //app.MapControllerRoute(name: "Route1",
            //                       pattern: "{controller=Route}/{action=Method2}/{id?}");



            //app.MapControllerRoute("Route1", "r1/{name:alpha}/{age:int:range(20,40)}/{id?}",
            //    new { controller = "Route", action = "Method1" });

            //app.MapControllerRoute("Route2", "r2", new { controller = "Route", action = "Method2" });
            #endregion
            //Employee/details
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");//Staff (declare - execute)
            #endregion
            app.Run();
        }
    }
}
