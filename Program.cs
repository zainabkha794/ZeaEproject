using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Eproject.Data;
using Eproject.Areas.Identity.Data;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("EprojectContextConnection") ?? throw new InvalidOperationException("Connection string 'EprojectContextConnection' not found.");

        builder.Services.AddDbContext<EprojectContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<EprojectUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<EprojectContext>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

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
            pattern: "{controller=User}/{action=Index}/{id?}");

        app.MapRazorPages();
        app.Run();
    }
}