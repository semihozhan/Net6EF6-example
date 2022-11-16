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
        private readonly ICourseService _courseService;
        private readonly IStudentCourseService _studentCourseService;

        public StudentController(IStudentService studentService, ICourseService courseService, IStudentCourseService studentCourseService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _studentCourseService = studentCourseService;
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
            ViewBag.courses = _courseService.GetAll().Result.Data;
            return View();
        }


        [HttpPost]
        [CanAdded]
        public async Task<IActionResult> Ekle(Student student)
        {
            var courses = Request.Form["skill"]; 
            var role = Request.Form["role"]; 
            student.RoleID = Convert.ToInt32(role);
         
           
         

            var result = await _studentService.Add(student);
            if (result.ResultStatus == ResultStatus.Success)
            {
                foreach (var item in courses)
                {
                    var studentcourseAdd = _studentCourseService.Add(
                        new StudentCourse { 
                            StudentId = result.Data.StudentId,
                            CourseId=Convert.ToInt32(item) }
                        );
                }
                
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
