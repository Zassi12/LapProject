using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAP.Logic;
using LAP.Web.Models;

namespace LAP.Web.Controllers
{
    public class BuchungenController : Controller
    {
        // GET: Buchung
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Kreditkartenbuchung()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KreditKartenBuchung(string kknummer)
        {
            
            KreditkartenModel kkmodel = new KreditkartenModel();
            kkmodel.IsValid = KreditkartenVerwaltung.CheckLUHN(kknummer);
            return View(kkmodel);
        }
    }
}