using Kusys.Mvc.Models;
using Kusys.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kusys.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService,ILogger<HomeController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username,string password)
        {
            //login giriş success ise session yarat
            var student = _studentService.LoginControl(username, password);
            if (student.Result.Data != null)
            {
                HttpContext.Session.SetInt32("Role", student.Result.Data.RoleID);
                HttpContext.Session.SetInt32("User", student.Result.Data.StudentId);
                return RedirectToAction("Index", "Student");
            }
            ModelState.AddModelError("LogOnError", "Kullanıcı adı veya şifre hatalı.");
            return View("Index", "Home");

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }
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