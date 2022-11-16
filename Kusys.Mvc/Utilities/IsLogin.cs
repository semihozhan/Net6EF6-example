using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Kusys.Mvc.Utilities
{
    public class IsLogin : ActionFilterAttribute
    {
        public int Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            bool isCorrect = true;


            if (filterContext.HttpContext.Session.GetInt32("User") ==null)
            {
                isCorrect = false;
            }
            

            if (!isCorrect)
            {
              
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                             new { controller = "Home", action = "Index" }));
            
            }
            base.OnActionExecuting(filterContext);
        }
    }





}
