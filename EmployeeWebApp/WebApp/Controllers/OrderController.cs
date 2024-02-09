using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApp.Models;
using System.Web;
using Dapper;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.CodeAnalysis;


namespace WebApp.Controllers
{
    
    public class OrderController : Controller
    {
        
        
        [HttpGet]
        [Authorize]
        [OutputCache(Duration = 100)]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Orders> ord;
            string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
            using (IDbConnection sql = new SqlConnection(conn))
            {
                string sqlstring = "Select * from Orders";
                ord = await sql.QueryAsync<Orders>(sqlstring);
            }
            Response.Headers.Add("Cache-Control", "public,max-age=3600");
            return View(ord);
        }



        [HttpGet]
        [OutputCache(Duration=100)]
        [Route("Select")]
        [Route("[controller]/[action]")]
        [Authorize]
        public IActionResult Details0()
        {
            Response.Headers.Add("Cache-Control", "public,max-age=3600");
            return View();
        }


        [HttpPost]
        [Route("Select")]
        [Route("[controller]/[action]")]
        public IActionResult Details0(Orders fc)
        {

                int orderid = fc.orderid;
                
                return RedirectToAction("Details", new { orderid = orderid });
           
           
        }
        [HttpGet]
        public async Task<IActionResult> Details(int orderid)
        {
            Orders obj;
            
            string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
            using (IDbConnection sql = new SqlConnection(conn))
            {
                string sqlstring = "Select * from Orders where orderid = @orderid";
                obj = await sql.QueryFirstOrDefaultAsync<Orders>(sqlstring, new {orderid = orderid});
            }
            
            return View(obj);
        }
       
    }
}
