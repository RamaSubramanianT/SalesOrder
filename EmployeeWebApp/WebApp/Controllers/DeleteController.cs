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
        public IActionResult delete()
        {
            return View();
        }
        [HttpPost]
        [Route("DeleteElement")]
        [Route("[controller]/[action]")]
        public IActionResult delete(Orders fc)
        {
            int id = fc.orderid;
            string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
            using (IDbConnection sql = new SqlConnection(conn))
            {
                string sqlstr = "delete from orders where orderid = @id";
                sql.Execute(sqlstr, new { id = id });
                Console.WriteLine("Success");
            }
            return View();
        }



    }
}
