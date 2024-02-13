using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Don't leave the field empty")]
        [StringLength(100)]
        [MinLength(2)]
        public string? username {  get; set; }

        [Required(ErrorMessage = "Don't leave the field empty")]
        [StringLength(100)]
        [MinLength(8)]
        [PasswordPropertyText]
        public string? password { get; set; }

    }
}
