using BCPLAlumniPortal.DBContext;
using BCPLAlumniPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BCPLAlumniPortal.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private DataBaseContext db;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(DataBaseContext _db, UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            db = _db;
            signInManager = _signInManager;
            userManager = _userManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.msg = "Test";

            return View();
        }
        [HttpPost]
        public IActionResult Index(string a)
        {
            ViewBag.msg = "Test";

            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string email, string password)
        {

            User user = new User { UserName = email, Email = email,EmployeeNumber = "1234", 
                Name ="Name", DateOfBirth = DateOnly.FromDateTime(DateTime.Today)};

            var result = await userManager.CreateAsync(user, password);

            //User userObj = new();
            //userObj.Email = email;
            //userObj.Password = password;


            ////userObj.Name = "Test User";
            ////userObj.EmployeeNumber = "1000";
            ////userObj.Address = "Address";

            ////userObj.MobileNumber = "1234";
            ////userObj.DateOfBirth = DateOnly.FromDateTime(DateTime.Now);

            ////userObj.UserName = "UserName";

            //db.User.Add(userObj);
            //db.SaveChanges();


            if(result.Succeeded)
            {
                TempData["succ_msg"] = "Registered successfully";
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            User user = db.User.Where(x=>x.Email == email).FirstOrDefault();    
            if(user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    // Logic for successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["err_msg"] = "Invalid Login";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["err_msg"] = "Invalid Login";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
