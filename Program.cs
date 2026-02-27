using Microsoft.EntityFrameworkCore;
using cprestegard_sp2026_assignment3.Data;
using cprestegard_sp2026_assignment3.Services;

namespace cprestegard_sp2026_assignment3;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        // Register EF Core DbContext
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register HttpClient-based services
        builder.Services.AddHttpClient<RedditService>();
        builder.Services.AddHttpClient<HuggingFaceSentimentService>();

        // Register VADER sentiment service (no HttpClient needed)
        builder.Services.AddSingleton<VaderSentimentService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
