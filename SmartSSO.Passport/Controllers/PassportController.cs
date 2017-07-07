using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSSO.Passport.Filters;

namespace SmartSSO.Passport.Controllers
{
    public class PassportController : Controller
    {
        // GET: Passport
        [Auth]
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult PassportVerify()
        {
            //认证cookie,如果不存在则登录
            HttpCookie cookie = Request.Cookies["UserName"];
            if (cookie == null || string.IsNullOrWhiteSpace(cookie.Value.ToString()))
            {
                return RedirectToAction("Login", new { Token = Request["Token"], AppKey = Request["AppKey"], ReturnURL = Request["ReturnURL"] });
            }

            //认证没有通过，继续登录
            if (Request["Token"] == null || Request["AppKey"] == null || Request["ReturnURL"] == null)
            {
                return RedirectToAction("Login", new { Token = Request["Token"], AppKey = Request["AppKey"], ReturnURL = Request["ReturnURL"] });

            }
            else
            {
                //认证AppKey 和token是否匹配，匹配则继续
                if (Request["Token"] != "11111" || Request["AppKey"] != "test")
                {
                    return RedirectToAction("Login", new { Token = Request["Token"], AppKey = Request["AppKey"], ReturnURL = Request["ReturnURL"] });
                }
                else
                {
                    string ReturnURL = Request["ReturnURL"] + "?Token=" + Request["Token"] + "&AppKey=" + Request["AppKey"];
                    return Redirect(ReturnURL);
                }
            }
        }


        public ActionResult Login()
        {
            ViewBag.Token = Request["Token"];
            ViewBag.AppKey = Request["AppKey"];
            ViewBag.ReturnURL = Request["ReturnURL"];

            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (userName == "admin" && password == "1")
            {
                HttpCookie cookie = new HttpCookie("UserName");
                cookie.HttpOnly = true;
                cookie.Value = "admin";
                cookie.Expires = DateTime.Now.AddHours(2);
                Response.Cookies.Add(cookie);

                if (Request["Token"] == null || Request["ReturnURL"] == null || Request["AppKey"] == null)
                {
                    return RedirectToAction("Index", "passport");
                }
                else
                {
                    string ReturnURL = Request["ReturnURL"] + "?Token=" + Request["Token"] + "&AppKey=" + Request["AppKey"];
                    return Redirect(ReturnURL);
                }
            }
            return View();
        }

        public ActionResult LoginOut()
        {
            HttpResponse response = System.Web.HttpContext.Current.Response;
            if (response != null)
            {
                HttpCookie cookie = response.Cookies["UserName"];
                if (cookie != null)
                {
                    cookie.Values.Remove("UserName");

                }
            }
            return View();
        }
    }
}