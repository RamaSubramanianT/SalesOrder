using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApp.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OutputCaching;


namespace WebApp.Controllers
{
    
    public class OrderController : Controller
    {
        
        
        [HttpGet]
        [Authorize]
        [OutputCache(Duration = 100, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Orders> ord;
            string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
            using (IDbConnection sql = new SqlConnection(conn))
            {
                string sqlstring = "Select * from Orders";
                ord = await sql.QueryAsync<Orders>(sqlstring);
            }
            Response.Headers.Append("Cache-Control", "public,max-age=360");
            return View(ord);
        }



        [HttpGet]
        
        [Route("Select")]
        [Route("[controller]/[action]")]
        [Authorize]
        public IActionResult Details0()
        {
            Response.Headers.Append("Cache-Control", "public,max-age=360");
            return View();
        }


        [HttpPost]
        [Route("Select")]
        [Route("[controller]/[action]")]
        public IActionResult Details0(Orders fc)
        {
            int orderid = fc.orderid;
            Console.WriteLine(orderid);
            return RedirectToAction("Details","Order", new { orderid = orderid });
        }
        [HttpGet]
        public async Task<IActionResult> Details(int orderid)
        {
            Orders? obj;
            Console.WriteLine(orderid);
            string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
            using (IDbConnection sql = new SqlConnection(conn))
            {
                string sqlstring = "Select * from Orders where orderid = @orderid";
                obj = await sql.QueryFirstOrDefaultAsync<Orders>(sqlstring, new {orderid = orderid});
            }
            if(obj == null)
            {
                ViewBag.Message = "No Record Found";
            }
            return View(obj);
        }
       
    }
}
