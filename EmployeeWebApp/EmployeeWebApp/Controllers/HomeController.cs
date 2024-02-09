using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
