using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public string ProductId { get; set; }

        [Required(ErrorMessage = "This field can not be empty")]
        [Range(1,100,ErrorMessage = "Out of Range")]
        
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
