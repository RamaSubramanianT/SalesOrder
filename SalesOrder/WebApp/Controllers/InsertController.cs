using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using WebApp.ViewModel;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class InsertController : Controller
    {
        private readonly ISelectInterface _selectInterface;             //Dependecy Injection : AddTransient
        public InsertController(ISelectInterface selectInterface) 
        {
            _selectInterface = selectInterface;   
        }

        [HttpGet]
        [Route("InsertElement")]
        [Route("[controller]/[action]")]
        public IActionResult Insert()
        {
            List<Orders> det = _selectInterface.getDetails();
            _selectInterface.setDetails(det);
            return View();
        }
        [HttpPost]
        [OutputCache(Duration = 60)]
        [Route("InsertElement")]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Insert(InsertVM fc)
        {
            if (ModelState.IsValid)
                {
                    int id = fc.orderid;
                    DateTime date = fc.orderdate;
                    string? prodid = fc.ProductId;
                    int uid = fc.UserId;

                    if (date < new DateTime(2020, 01, 01))
                    {
                        ViewBag.dateMessage = "Please enter a date after 01/01/2020";
                        return View();
                    }

                    string temp = Convert.ToString(date);
                    string[] temp1 = new string[2];
                    temp1 = temp.Split(" ");
                    string dat = temp1[0];

                    string conn = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=Interns;password=test;";
                    try
                    {
                        using (IDbConnection sql = new SqlConnection(conn))
                        {
                            string sqlstring = "insert into Orders(orderid,orderdate,ProductId,UserId) values(@id,@date,@pid,@uid)";
                            await sql.ExecuteAsync(sqlstring, new { id = id, date = dat, pid = prodid, uid = uid });
                            sqlstring = "Exec updatequantity @uid,@oid";
                            await sql.ExecuteAsync(sqlstring, new { uid = uid, oid = id });
                            sqlstring = "Exec updaterealprice @oid";
                            await sql.ExecuteAsync(sqlstring, new { oid = id });
                            Console.WriteLine("Success");
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = ex.Message;
                        return View();
                    }
                    Console.WriteLine($"{id}  {dat}\t\t{prodid}  {uid}");

                    return RedirectToAction("Index", "Order");
                }
            
            return View();

        }
    }
}
