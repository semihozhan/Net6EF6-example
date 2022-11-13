using Kusys.Entities;
using Kusys.Mvc.Utilities;
using Kusys.Services.Abstract;
using Kusys.Shared.Utilities.Result.ComplexType;
using Microsoft.AspNetCore.Mvc;

namespace Kusys.Mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService= studentService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _studentService.GetAll();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            
            return View();
        }


        [HttpPost]
        [CanAdded]
        public async Task<IActionResult> Ekle(Student student)
        {
             student.RoleID = 1;
        
             var result = await _studentService.Add(student);
      

            return View();
        }
    }
}
