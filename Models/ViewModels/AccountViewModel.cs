using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BCPLAlumniPortal.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string EmployeeNumber { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
