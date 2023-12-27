using BCPLAlumniPortal.DBContext;
using BCPLAlumniPortal.Hubs;
using BCPLAlumniPortal.Models;
using BCPLAlumniPortal.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics;
using System.Security.Claims;

namespace BCPLAlumniPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IConfiguration Configuration;
        private DataBaseContext db;
        private readonly IHubContext<NotificationHub> hubContext;

        public HomeController(DataBaseContext _db, IConfiguration configuration, IHubContext<NotificationHub> _hubContext)
        {
            db = _db;
            Configuration = configuration;
            hubContext = _hubContext;
        }

        public IActionResult Index()
        {
            int claimCount = db.UserMedicalClaim.Count();
            hubContext.Clients.All.SendAsync("ReceiveMessage", claimCount.ToString());
            return View();
        }
        [HttpGet]
        public IActionResult NewClaim()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewClaim(MedicalClaimViewModel claimData)
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

                if(claimData.File != null && claimData.File.Any())
                {
                    // get file upload path from appsettings.json
                    string fileRootPath = Configuration.GetSection("AppSettings")["UploadFileRootPath"];  // Get Upload Files Root Path from appsettings.json
                    // create folder path specific for current application function
                    string[] paths = { fileRootPath, "MedicalClaimAttachment"}; 
                    string fileSaveDir = Path.Combine(paths); // combine paths
                    Directory.CreateDirectory(fileSaveDir); // create folder

                    List<UserMedicalClaimAttachment> attachments = new ();
                    foreach (var file in claimData.File)
                    {
                        if (file.ContentType.Contains(("image/")) || file.ContentType == "application/pdf")
                        {
                            if(file.Length <= 5144576)
                            {
                                // create filename with file extension
                                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                                // prepare final file path
                                string fileSavePath = Path.Combine(fileSaveDir, fileName);

                                var attachment = new UserMedicalClaimAttachment
                                {
                                    FileName = fileName,
                                    FileType = file.ContentType,
                                    FilePath = fileSavePath,
                                    FileSize = file.Length
                                };
                                attachments.Add(attachment);

                                // save file to directory from file stream
                                using var stream = System.IO.File.Create(fileSavePath);
                                await file.CopyToAsync(stream);
                            }
                        }
                    }

                    claim.attachments = attachments;
                }

                db.UserMedicalClaim.Add(claim);
                db.SaveChanges();

                int claimCount = db.UserMedicalClaim.Count();
                await hubContext.Clients.All.SendAsync("ClaimNotification", claimCount.ToString());
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

        public IActionResult ClaimDetails(Guid id)
        {
            UserMedicalClaim claim = db.UserMedicalClaim.Where(x => x.id == id).Include(m => m.attachments).FirstOrDefault();
            return View(claim);
        }

        public async Task<IActionResult> SignalRSendAsync(string message)
        {
            await hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            return RedirectToAction("Index");
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
