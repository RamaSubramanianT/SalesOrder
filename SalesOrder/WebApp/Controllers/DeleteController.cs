using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApp.ViewModel;
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
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteVM fc)
        {
            int id = fc.orderid;
            
            Console.WriteLine("Delete " + fc);
            int temp;

            string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
            using (IDbConnection sql = new SqlConnection(conn))
            {
                string sqlstr = "delete from orders where orderid = @id";
                temp = sql.Execute(sqlstr, new { id = id });
                Console.WriteLine("Success");
            }

            if(temp == 0)
            {
                ViewBag.Message = "No Record Found";
                return View();
            }
            return RedirectToAction("Details0", "Order");
            
        }
    }
}
