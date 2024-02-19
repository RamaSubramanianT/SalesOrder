using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using log4net;
using Serilog.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Models;
using Microsoft.AspNetCore.Antiforgery;
using System.Collections.Generic;

public class Program {
    public static void Main(string[] args)
    {
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

        builder.Services.AddLog4net();

        builder.Services.AddScoped<ISelectInterface, SelectDetails>();

        builder.Services.AddSingleton<ISelectInterface, GetDetails>();

        builder.Services.AddWebOptimizer((pipeline =>
        {
            pipeline.AddJavaScriptBundle("/js/bundle.js", "js/**/*.js", "lib/bootstrap/dist/js/**/*.js", "lib/jquery/dist/**/*.js");
            pipeline.AddCssBundle("/css/bundle.css", "/css/file1.css", "/css/site.css");

        }));

        builder.Services.AddAntiforgery(options =>
        {
            // Set Cookie properties using CookieBuilder properties†.
            options.FormFieldName = "AntiforgeryFieldname";
            options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
            options.SuppressXFrameOptionsHeader = false;
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseWebOptimizer();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseResponseCaching();

        app.UseOutputCache();

        app.UseAuthorization();

        app.UseSerilogRequestLogging();

        app.Use((context, next) =>
        {
            var header = context.Response.Headers;
            header.Add("Message", "Developed By Ram");
            header.Add("Message1", "Powered By OjCommerce");
            header.Add("Message2", "Developed Using Asp.Net Core");
            //header.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' stackpath.bootstrapcdn.com; style-src 'self' stackpath.bootstrapcdn.com;");
            
            return next();
        });

    



        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Login}/{orderid?}");

        app.MapRazorPages();


        

        app.Run();

    }

}
public static class Log4netExtensions
{
    public static void AddLog4net(this IServiceCollection services)
    {
        
        XmlConfigurator.Configure(new FileInfo("C:/Users/ramasubramanian/source/GitRepos/OrderWebApp/SalesOrder/WebApp/web.config"));
        services.AddSingleton(LogManager.GetLogger(typeof(Program)));
    }
}

