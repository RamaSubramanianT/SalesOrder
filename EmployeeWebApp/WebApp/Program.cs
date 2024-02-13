using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Exceptions;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebAppDbConnection") ?? throw new InvalidOperationException("Connection string 'WebAppDbConnection' not found.");

builder.Services.AddControllersWithViews();

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"));



builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Home/Login";
        option.ExpireTimeSpan = TimeSpan.FromSeconds(160);
    });

builder.Services.AddOutputCache(
        options =>
        {
            options.SizeLimit = 1000;
            options.MaximumBodySize = 1000;
            options.AddBasePolicy(
                    basepolicy => basepolicy.Expire(TimeSpan.FromSeconds(120))
                );
            options.AddBasePolicy(builder => builder.Tag("tag-all"));
        }
    );

builder.Services.AddResponseCaching(
    options =>  
    {
        options.SizeLimit = 1000;
        options.MaximumBodySize = 1000;
        
    }
    );

builder.Services.AddAuthorization();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseResponseCaching();

app.UseOutputCache();

app.UseAuthorization();

app.UseSerilogRequestLogging();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{orderid?}");

app.MapRazorPages();

app.Run();
 