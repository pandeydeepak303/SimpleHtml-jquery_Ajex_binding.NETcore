using Microsoft.AspNetCore.Mvc;
using PracticeProjectLive.Empmodel;
using PracticeProjectLive.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PracticeProjectLive.Controllers
{
    public class AccountController : Controller
    {

        DemoLiveContext _db;

        public AccountController()
        {    
         _db = new DemoLiveContext();

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var user = _db.TblUser.FirstOrDefault(x => x.UserName == Username);
            if (user != null && EncryptPassword(Password) == user.Password && user.Password != null)
            {
                return Json(new { redirectUrl = Url.Action("EmpIndex", "Employee") });
            }
            else
            {    
             return Json(new { error = "Invalid username or password" });
            }
        }
                   

        [HttpGet]
        public IActionResult Regisrtration()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Regisrtration(SignupVm signupVm)
        {     
                if (ModelState.IsValid)
                {
                    using (DemoLiveContext entities = new DemoLiveContext())
                    {
                     
                        TblUser  user = new TblUser
                        {
                            UserName = signupVm.UserName,
                            Password = EncryptPassword(signupVm.Password),
                            Email= signupVm.Email,
                            Mobile = signupVm.Mobile,
                           
                        };
                        entities.TblUser.Add(user);
                        entities.SaveChanges();
                    }

                 return Json(new { success = true });

                }
                return Json(new { success = false, message = "Validation failed." });
            
            }


        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}
