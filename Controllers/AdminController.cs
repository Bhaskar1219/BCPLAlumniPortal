using BCPLAlumniPortal.DBContext;
using BCPLAlumniPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Configuration;

namespace BCPLAlumniPortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private DataBaseContext db;
        private readonly IConfiguration Configuration;
        public AdminController(DataBaseContext _db, IConfiguration configuration)
        {
            db = _db;
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUsers()
        {
            return View();
        }
        public IActionResult ListMedicalClaims()
        {
            List<UserMedicalClaim> claims = db.UserMedicalClaim.ToList();
            return View(claims);
        }
    }
}
