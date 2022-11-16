using Kusys.Mvc.Utilities;
using Kusys.Services.Abstract;
using Kusys.Shared.Utilities.Result.ComplexType;
using Microsoft.AspNetCore.Mvc;

namespace Kusys.Mvc.Controllers
{
    [IsLogin]
    public class CourseController : Controller
    {

        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _courseService.GetAll();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
    }
}
