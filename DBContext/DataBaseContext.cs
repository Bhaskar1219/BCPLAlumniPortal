using BCPLAlumniPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BCPLAlumniPortal.Models.ViewModels;

namespace BCPLAlumniPortal.DBContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserMedicalClaim> UserMedicalClaim { get; set; }
        public DbSet<BCPLAlumniPortal.Models.ViewModels.MedicalClaimViewModel> MedicalClaimViewModel { get; set; } = default!;
    }
}
