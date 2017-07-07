using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSSO.Client.Filters
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var response = filterContext.HttpContext.Response;

            if (request["Token"] == null || request["AppKey"] == null)
            {
                string Passport = System.Configuration.ConfigurationManager.AppSettings["Passport"];
                string AppKey = System.Configuration.ConfigurationManager.AppSettings["AppKey"];
                string Token = System.Configuration.ConfigurationManager.AppSettings["Token"];
                string ReturnURL = request.Url.AbsoluteUri;


                filterContext.Result = new RedirectResult(string.Format("{0}/Passport/PassportVerify?AppKey={1}&Token={2}&ReturnURL={3}",
                 Passport, AppKey, Token, ReturnURL));
                return;
            }

        }
    }
}