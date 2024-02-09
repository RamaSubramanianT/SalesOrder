using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Don't leave the field empty")]
        public string username {  get; set; }

        [Required(ErrorMessage = "Don't leave the field empty")]
        public string password { get; set; }
    }
}
