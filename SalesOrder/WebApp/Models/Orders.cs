using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace WebApp.Models
{
    public class Orders
    {
        [Required(ErrorMessage = "This field can not be empty")]
        [Range(1,100,ErrorMessage = "Input a number within range 1-100")]
        public int orderid { get; set; }
        [Required(ErrorMessage = "This field can not be empty")]
        public DateTime orderdate { get; set; }
        
        public decimal price { get; set; }

        [Required(ErrorMessage = "This field can not be empty")]
        [Display(Name = "Product Id number")]
        [MinLength(3, ErrorMessage = "Enter Valid Product Id")]
        [MaxLength(12, ErrorMessage = "Value Length Exceeded 12 characters")]
        public string? ProductId { get; set; }

        [Required(ErrorMessage = "This field can not be empty")]
        [Range(1,100,ErrorMessage = "Out of Range")]
        public int UserId { get; set; }

        public int quantity { get; set; }
        public decimal totalprice { get; set; }

        public Orders() {
            orderid = 0;
            orderdate = new DateTime();
            price = 0m;
            ProductId = "";
            UserId = 1;
            quantity = 0;
            totalprice = 0m;
        }
        public Orders(int id, DateTime dat,decimal prc, string pid, int uid,int quan, decimal ttprc)
        {
            this.orderid = id;
            this.orderdate = dat;
            this.price = prc;
            this.ProductId = pid;
            this.UserId = uid;
            this.quantity = quan;
            this.totalprice = ttprc;
        }
    }
}
