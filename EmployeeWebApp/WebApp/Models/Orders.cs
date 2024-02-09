using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Orders
    {
        [Required(ErrorMessage = "This field can not be empty")]
        public int orderid { get; set; }
        [Required(ErrorMessage = "This field can not be empty")]
        public DateTime orderdate { get; set; }
        
        public decimal price { get; set; }

        [Required(ErrorMessage = "This field can not be empty")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "This field can not be empty")]
        public int UserId { get; set; }

        public int quantity { get; set; }
        public decimal totalprice { get; set; }

        public Orders() { }

        public Orders(int id, DateTime dat, string pid, int uid)
        {
            this.orderid = id;
            this.orderdate = dat;
            this.ProductId = pid;
            this.UserId = uid;
        }
    }
}
