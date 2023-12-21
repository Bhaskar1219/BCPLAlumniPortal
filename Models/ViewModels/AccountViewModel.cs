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
}
