using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyDubai.Web.App_Code
{
    public class SessionChecker : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            // check  sessions here
            if (HttpContext.Current.Session["currentuser"] == null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/account/logout");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
