using LAP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAP.Web.Controllers
{
    public class FirmenController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Firmen(FirmenModel fm)
        {


            return View();
        }


    }
}