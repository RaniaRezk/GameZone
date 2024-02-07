using Game_Zone.Data;
using Game_Zone.Services;
using Microsoft.EntityFrameworkCore;

namespace Game_Zone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(
               Options => Options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")
                   )
               );
            builder.Services.AddScoped<ICategories_Services, Categories_Services>();
            builder.Services.AddScoped<IDevicesServices,DevicesServices>();
            builder.Services.AddScoped<IGamesServices,GamesServices>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}/{id?}");

            app.Run();
        }
    }
}