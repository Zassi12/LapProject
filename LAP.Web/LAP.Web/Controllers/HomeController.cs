using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAP.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.message = "";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Agb()
        {
            ViewBag.Message = "Your Agb page.";

            return View();
        }

        public ActionResult Impressum()
        {
            ViewBag.Message = "Your Impressum page.";

            return View();
        }
    }
}