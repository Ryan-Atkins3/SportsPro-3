using System.ComponentModel.DataAnnotations;

namespace Case_Study_3_1.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "You must enter a First Name")]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter a Last Name")]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter a UserName")]
        [StringLength(200)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter a password")]
        [Compare("ConfirmPassword")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "You confirm your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
