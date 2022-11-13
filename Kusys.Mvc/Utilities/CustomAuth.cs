using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Kusys.Mvc.Utilities
{
    public class CanAdded : ActionFilterAttribute
    {
        public int Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            bool isCorrect = true;
            string resultMessage = string.Empty;


            if (filterContext.HttpContext.Session.GetInt32("role") != 1)
            {
                isCorrect = false;
                resultMessage = "Kullanıcının ekleme yetkisi yok";
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
