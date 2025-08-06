using Microsoft.EntityFrameworkCore;
using codefirst1.Models;

namespace codefirst1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add DbContext for EF Core
            builder.Services.AddDbContext<RecipeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecipeConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Recipes}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
