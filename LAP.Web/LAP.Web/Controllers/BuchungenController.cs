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
        public ActionResult Kreditkartenbuchung(int id)
        {
            Benutzer user = BenutzerVerwaltung.getBenutzer(User.Identity.Name);
            KreditkartenModel kkmodel = new KreditkartenModel();
            kkmodel.Id_Buchung = 1;
            kkmodel.Vorname = user.Vorname;
            kkmodel.Nachname = user.Nachname;
            return View(kkmodel);
        }
        [HttpPost]
        public ActionResult KreditKartenBuchung(string kknummer)
        {
            
            KreditkartenModel kkmodel = new KreditkartenModel();
            if (KreditkartenVerwaltung.CheckLUHN(kknummer))
            {
                kkmodel.IsValid = KreditkartenVerwaltung.CheckLUHN(kknummer);
                TempData["erfolg"] = "Erfolgreich Gebucht!";
            }
            else
            {

                TempData["fehler"] = "KreditKarten-Nummer ist falsch!";
            }
            kkmodel.IsValid = KreditkartenVerwaltung.CheckLUHN(kknummer);
            return View(kkmodel);
        }
    }
}