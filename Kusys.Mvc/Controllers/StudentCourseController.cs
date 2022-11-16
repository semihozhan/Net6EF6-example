using Kusys.Entities;
using Kusys.Mvc.Utilities;
using Kusys.Services.Abstract;
using Kusys.Shared.Utilities.Result.ComplexType;
using Microsoft.AspNetCore.Mvc;

namespace Kusys.Mvc.Controllers
{
    [IsLogin]
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourseService _studentService;

        public StudentCourseController(IStudentCourseService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            int session = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
            if (session>0)
            {
                var result = await _studentService.GetAll(session);
                if (result.ResultStatus == ResultStatus.Success)
                {
                   
                    return View(result.Data);
                }
            }
            else
            {
                var result = await _studentService.GetAll(null);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return View(result.Data);
                }
            }
            
            return View();
        }
    }
}
