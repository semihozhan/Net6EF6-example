using Kusys.Entities;
using Kusys.Mvc.Utilities;
using Kusys.Services.Abstract;
using Kusys.Shared.Utilities.Result.ComplexType;
using Microsoft.AspNetCore.Mvc;


namespace Kusys.Mvc.Controllers
{
    [IsLogin]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
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
            if (result.ResultStatus == ResultStatus.Success)
            {
                return RedirectToAction("Index", "Student");
            }

            return View();
        }


        [HttpGet]
        [CanAdded]
        public async Task<IActionResult> Guncelle(int id)
        {
            var result = await _studentService.Get(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Guncelle(int StudentId, string FirstName, string LastName,DateTime BirthDate)
        {
            var student = await _studentService.Get(StudentId);
            student.Data.FirstName = FirstName;
            student.Data.LastName = LastName;
            student.Data.BirthDate = BirthDate;

            var result = await _studentService.Update(student.Data);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return RedirectToAction("Index", "Student");
            }
            return View();
        }

        [HttpGet]
        [CanAdded]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.Get(id);

            var result = await _studentService.Delete(student.Data);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return RedirectToAction("Index", "Student");
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var student =  _studentService.Get(id);
            return Json(student.Result.Data);
        }
    }
}
