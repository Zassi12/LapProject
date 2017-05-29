using LAP.Web.Models;
using LAP.Logic;
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
            return RedirectToAction("Index", "Home"); ;
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            FirmenModel model = new FirmenModel();
            var firma = FirmenVerwaltung.GetFirma(id);

            model.Stadt = firma.Stadt;
            model.FirmenName = firma.FirmenName;
            model.HausNummer = firma.Hausnummer;
            model.Straße = firma.Straße;
            model.Plz = firma.Plz;
            

            return View(model);
        }


    }
}