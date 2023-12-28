using AspNetCore.ReCaptcha;
using BCPLAlumniPortal.DBContext;
using BCPLAlumniPortal.Models;
using BCPLAlumniPortal.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BCPLAlumniPortal.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private DataBaseContext db;

        public AccountController(DataBaseContext _db)
        {
            db = _db;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userData)
        {

            User user = new User { 
                UserName = userData.Email, 
                Email = userData.Email,
                EmployeeNumber = userData.EmployeeNumber, 
                Name = userData.Name,
                Address = userData.Address,
                MobileNUmber = userData.MobileNumber,
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today),
                AccessFailedCount = 0,
            };

            PasswordHasher<User> hasher = new();
            user.Password = hasher.HashPassword(user, userData.Password);
            List<UserRole> roles = new List<UserRole>();
            roles.Add(new() { RoleName = "User" });
            user.Roles = roles;

            db.User.Add(user);
            db.SaveChanges();

            TempData["succ_msg"] = "Registered successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateReCaptcha]
        public async Task<IActionResult> Login(LoginViewModel data)
        {
            if (ModelState.IsValid)
            {
                User user = db.User.Where(x => x.Email == data.UserName).Include(x => x.Roles).FirstOrDefault();
                if (user != null)
                {
                    PasswordHasher<User> hasher = new();
                    var result = hasher.VerifyHashedPassword(user, user.Password, data.Password);

                    if (result.Equals(PasswordVerificationResult.Success))
                    {
                        // create a new claim
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Sid, user.Id.ToString()),
                        new Claim("EmployeeNumber", user.EmployeeNumber),
                    };

                        if (user.Roles != null && user.Roles.Any())
                        {
                            foreach (var role in user.Roles)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                            }
                        }

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            //AllowRefresh = <bool>,
                            // Refreshing the authentication session should be allowed.

                            //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                            // The time at which the authentication ticket expires. A 
                            // value set here overrides the ExpireTimeSpan option of 
                            // CookieAuthenticationOptions set with AddCookie.

                            //IsPersistent = true,
                            // Whether the authentication session is persisted across 
                            // multiple requests. When used with cookies, controls
                            // whether the cookie's lifetime is absolute (matching the
                            // lifetime of the authentication ticket) or session-based.

                            IssuedUtc = DateTime.Now,
                            // The time at which the authentication ticket was issued.

                            //RedirectUri = <string>
                            // The full path or absolute URI to be used as an http 
                            // redirect response value.
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), authProperties);

                        return RedirectToAction("Index", "Home");
                    }
                    TempData["err_msg"] = "Invalid Login";
                    return RedirectToAction("Index");
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
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
