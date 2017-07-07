using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSSO.Client.B.Filters;

namespace SmartSSO.Client.B.Controllers
{
    public class HomeController : Controller
    {
        [Auth]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}