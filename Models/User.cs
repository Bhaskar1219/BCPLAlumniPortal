using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BCPLAlumniPortal.Models
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string? Address { set; get; }
        public DateOnly DateOfBirth { set; get; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
