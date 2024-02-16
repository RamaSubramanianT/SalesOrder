using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class UpdateController : Controller
    {
        private readonly ISelectInterface _selectdetails;
        public UpdateController(ISelectInterface selectdetails)
        {
            _selectdetails = selectdetails;
        }

        [HttpGet]
        [Route("Update")]
        [Route("[controller]/[action]")]
        [Authorize]
        public IActionResult update0()
        {
            List<Orders> ord = _selectdetails.getDetails();
            _selectdetails.setDetails(ord);
            _selectdetails.getId(ord);
            return View();
        }


        [HttpPost]
        [Route("Update")]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> update0(UpdateVM fc)
        {
            int tem;
            Console.WriteLine("Flag");
            int id = fc.orderid;
            DateTime date = fc.orderdate;

            string temp = Convert.ToString(date);
            string[] temp1 = new string[2];
            temp1 = temp.Split(" ");
            string dat = temp1[0];

            string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
            using (IDbConnection sql = new SqlConnection(conn))
            {
                string sqlstring = "update Orders set orderdate = @date where orderid=@id";
                tem = await sql.ExecuteAsync(sqlstring, new { id = id, date = dat });
                Console.WriteLine("Update Success");
            }
            if (tem == 0)
            {
                ViewBag.Message = "No Record Found";
                return View();
            }
            return RedirectToAction("Details0", "Order", new { orderid = id });
        }
    }
}
