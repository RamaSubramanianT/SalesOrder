using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using Dapper;
using System.Data.SqlClient;
using System.Security.Authentication;
using System.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol;
using System.Drawing.Drawing2D;
using System.IO;


namespace WebApp.Controllers
{
    namespace WebAppUser
    {
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;

            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }


            [HttpGet]
            [Route("")]
            [Route("[controller]/[action]")]
            public IActionResult Login()
            {

                return View();
            }

            [HttpPost]
            [Route("")]
            [Route("[controller]/[action]")]
            public async Task<IActionResult> LoginAsync(Login lg)
            {
                Console.WriteLine(lg.username);
                Console.WriteLine(lg.password);
                string temp;
                int flag = 0;
                string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
                using (IDbConnection sql = new SqlConnection(conn))
                {
                    string sqlstring = "select passwd from loginuser where username = @usr";
                    temp = sql.QueryFirstOrDefault<string>(sqlstring, new { usr = lg.username });
                    if (temp == lg.password)
                    {
                        flag = 1;

                    }
                    else
                    {
                        flag = 0;
                    }
                }

                if (flag == 1)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, lg.username),
                    // Add more claims as needed
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        // Customize properties if needed
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect Credentials";
                    return RedirectToAction("Login", "Home", new { lg = lg });
                }


            }
            [HttpGet]
            public async Task<IActionResult> Logout()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Logout(Login lg)
            {
                if (lg.username == "Yes" || lg.username == "yes" || lg.username == "y")
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                    Response.Headers["Pragma"] = "no-cache";
                    Response.Headers["Expires"] = "0";
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Order");
                }
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
