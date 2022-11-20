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


            if (filterContext.HttpContext.Session.GetInt32("Role") != 1)
            {
                isCorrect = false;
                resultMessage = "Kullanıcının ekleme,silme ve güncelleme yetkisi yok";
            }
            

            if (!isCorrect)
            {
              
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                             new { controller = "Student", action = "UnAuthorized" }));
            
            }
            base.OnActionExecuting(filterContext);
        }
    }





}
