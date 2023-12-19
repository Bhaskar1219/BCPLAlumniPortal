using BCPLAlumniPortal.DBContext;
using BCPLAlumniPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BCPLAlumniPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DataBaseContext db;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public HomeController(DataBaseContext _db, UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            db = _db;
            signInManager = _signInManager;
            userManager = _userManager;
        }



        public void GetUser()
        {
            User userObj = db.User.Where(m=>m.EmployeeNumber == "1000").FirstOrDefault();

            userObj.Address = "New Address";
            db.Entry(userObj).State = EntityState.Modified;
            db.SaveChanges();

            // select * from User where Employeenumber = '1234'

        }

        public IActionResult Index()
        {
            return View();
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
