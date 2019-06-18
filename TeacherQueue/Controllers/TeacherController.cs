using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TeacherQueue.DAL;
using TeacherQueue.Helpers;
using TeacherQueue.Models.DatabaseModels;
using TeacherQueue.Models.ViewModels;

namespace TeacherQueue.Controllers
{
    public class TeacherController : Controller
    {
        private readonly QueueContext _context;

        public TeacherController(QueueContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password.Equals(model.ConfirmationPassword))
                {
                    //checks if the email is already registered
                    var teacherExist = _context.Teachers.Any(o => o.Email == model.Email);

                    if (!teacherExist)
                    {
                        //if teacher DOES NOT exist yet, register the teacher.

                        //create Hasher
                        HashHelper hasher = new HashHelper();

                        //create teacher model, encrypt password
                        Teacher newTeacher = new Teacher
                        {
                            FirstMidName = model.FirstMidName,
                            LastName = model.LastName,
                            Email = model.Email,
                            Salt = hasher.GenerateSalt(),
                            HasQueue = false,
                        };
                        newTeacher.Password = hasher.Encrypt(model.Password, newTeacher.Salt);

                        //add teacher to DB
                        _context.Teachers.Add(newTeacher);
                        _context.SaveChanges();

                        return RedirectToAction("Login");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            const string mainError = "You have entered an invalid emailaddress or password!";
            if (ModelState.IsValid)
            {
                //create instance of (Password)Hasher
                var hasher = new HashHelper();

                var user = _context.Teachers.SingleOrDefault(o => o.Email == model.Email);

                if (user != null)
                {
                    //user with email exists in database, check password
                    if (hasher.VerifyPassword(model.Password, user.Password, user.Salt))
                    {
                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, user.Email),
                            new Claim("FullName", user.FirstMidName + " " + user.LastName)
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(identity));
                        return RedirectToAction("Queue", "Queue");
                    }
                    else
                    {
                        ModelState.AddModelError("", mainError);
                    }
                }
                else
                {
                    ModelState.AddModelError("", mainError);
                }
                return View(model);
            }

            return View(model);
        }

        public async void LogOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}