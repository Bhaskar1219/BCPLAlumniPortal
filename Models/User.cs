using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BCPLAlumniPortal.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobileNUmber { get; set; }
        public int AccessFailedCount { get; set; }
        public string? Address { set; get; }
        public DateOnly DateOfBirth { set; get; }
        public string? PasswordResetCode { get; set; }
        public ICollection<UserRole> Roles { get; set; }
        public ICollection<UserMedicalClaim> medicalClaims { get; set; }
        
    }
}
