using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class Startup {

    private readonly IConfiguration _config;
    public Startup(IConfiguration config) {
        _config = config;

    }
    public void ConfigureServices(IServiceCollection services) {
        services.AddDbContext<DataContext>(Options => 
        {
           Options.UseSqlite(_config.GetConnectionString("Connection string")); 
        });
        services.AddControllers();
    }
    public void Configure(WebApplication app, IWebHostEnvironment env) {
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}