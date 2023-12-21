using BCPLAlumniPortal.DBContext;
using BCPLAlumniPortal.Models;
using BCPLAlumniPortal.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace BCPLAlumniPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DataBaseContext db;

        public HomeController(DataBaseContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewClaim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewClaim(MedicalClaimViewModel claimData)
        {
            if (ModelState.IsValid)
            {
                var empNum = User.FindFirst(x => x.Type == "EmployeeNumber").Value;
                var userName = User.FindFirst(x => x.Type == ClaimTypes.Name).Value;

                UserMedicalClaim claim = new()
                {
                    claimAmount = claimData.claimAmount,
                    claimDate = DateTime.Now,
                    gender = claimData.gender,
                    patientName = claimData.patientName,
                    isEmpanelled = claimData.isEmpanelled,
                    patientRelationship = claimData.patientRelationship,
                    employeeNumber = empNum,
                    userName = userName
                };
                db.UserMedicalClaim.Add(claim);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewClaims()
        {
            var empNum = User.FindFirst(x => x.Type == "EmployeeNumber").Value;
            List<UserMedicalClaim> claims = db.UserMedicalClaim.Where(y=>y.employeeNumber == empNum).ToList();
            return View(claims);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
