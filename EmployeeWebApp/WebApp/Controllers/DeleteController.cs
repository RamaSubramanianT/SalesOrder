using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApp.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    public class DeleteController : Controller
    {
        [HttpGet]
        [Route("DeleteElement")]
        [Route("[controller]/[action]")]
        [Authorize]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        [Route("DeleteElement")]
        [Route("[controller]/[action]")]
        public IActionResult Delete(Orders fc)
        {
            int id = fc.orderid;
            
                Console.WriteLine("Delete " + fc);

                
                string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
                using (IDbConnection sql = new SqlConnection(conn))
                {
                    string sqlstr = "delete from orders where orderid = @id";
                    sql.Execute(sqlstr, new { id = id });
                    Console.WriteLine("Success");
                }
                return RedirectToAction("Details0", "Order");
            
        }



    }
}
