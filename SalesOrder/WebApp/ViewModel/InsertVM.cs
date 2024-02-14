using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModel
{
    public class InsertVM
    {
        [Required(ErrorMessage = "This field can not be empty")]
        [Range(1, 100, ErrorMessage = "Input a number within range 1-100")]
        public int orderid { get; set; }
        [Required(ErrorMessage = "This field can not be empty")]
        public DateTime orderdate { get; set; }
        [Display(Name = "Product Id number")]
        [MinLength(3, ErrorMessage = "Enter Valid Product Id")]
        [MaxLength(12, ErrorMessage = "Value Length Exceeded 12 characters")]
        [Required(ErrorMessage = "This field can not be empty")]
        public string? ProductId { get; set; }

        [Required(ErrorMessage = "This field can not be empty")]
        [Range(1, 100, ErrorMessage = "Out of Range")]
        public int UserId { get; set; }

    }
}
