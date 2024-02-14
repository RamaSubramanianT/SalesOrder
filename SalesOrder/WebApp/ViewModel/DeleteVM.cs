using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModel
{
    public class DeleteVM
    {
        [Required(ErrorMessage = "This field can not be empty")]
        [Range(1, 100, ErrorMessage = "Input a number within range 1-100")]
        public int orderid { get; set; }
    }
}
