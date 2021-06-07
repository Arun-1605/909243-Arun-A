using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECart_UI.Controllers
{
    public class SecureController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var Session = filterContext.HttpContext.Session;
            if (Session["IsAuthenticated"] == null || Session["UserId"] == null)
                filterContext.Result = new RedirectResult("/Account/Login");
        }
        public int UserId { get => Convert.ToInt32(Session["UserId"]); }
    }
}