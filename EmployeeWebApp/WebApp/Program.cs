using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebAppDbConnection") ?? throw new InvalidOperationException("Connection string 'WebAppDbConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Home/Login";
        option.ExpireTimeSpan = TimeSpan.FromSeconds(60);
    });

builder.Services.AddOutputCache(
        options =>
        {
            options.SizeLimit = 1000;
            options.MaximumBodySize = 1000;
            options.AddBasePolicy(
                    basepolicy => basepolicy.Expire(TimeSpan.FromSeconds(10))
                );
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
app.UseResponseCaching();
app.UseOutputCache();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{orderid?}");

app.MapRazorPages();

app.Run();
 