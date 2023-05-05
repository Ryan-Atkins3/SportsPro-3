using System.ComponentModel.DataAnnotations;

namespace Case_Study_3_1.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You must enter a UserName")]
        [StringLength(200)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public string ReturnUrl { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
