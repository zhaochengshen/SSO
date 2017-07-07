using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSSO.Passport.Filters
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            var request = filterContext.HttpContext.Request;

            if (request.Cookies["UserName"] == null || request.Cookies["UserName"].Value != "admin")
            {
                response.RedirectToRoute(new { Controller = "Passport", Action = "Login" });
            } 
        }
    }
}