using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAP.Logic;
using log4net;
using LAP.Web.Models;

namespace LAP.Web.Controllers
{
    public class MitarbeiterController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Mitarbeiter
        [HttpGet]
        public ActionResult Index()
        {
            log.Info("GET - Company - Index");


            List<Firma> allCompanies = FirmenVerwaltung.GetAlleFirmen();


            var model = new List<Models.FirmenModel>();

            foreach (var company in allCompanies)
            {
                model.Add(new Models.FirmenModel()
                {
                    ID = company.Id,
                    FirmenName = company.FirmenName,
                    HausNummer = company.Hausnummer,
                    Straße = company.Straße,
                    Plz = company.Plz,
                    Stadt = company.Stadt
                });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Stornierungen()
        {
            var storno = BuchungsVerwaltung.AlleStornierungen();
            var model = new List<StornoModel>();
            foreach (var b in storno)
            {
                model.Add(new StornoModel{
                    Grund = b.Grund,
                    Benutzername = b.Benutzer.Email,
                    Datum=b.Buchung.Datum,
                     Gebäude = b.Buchung.Räume.Gebäude.Hausnummer,
                     Firma = b.Benutzer.Firma.FirmenName,
                     Raum = b.Buchung.Räume.Beschreibung,
                     User = b.Benutzer

                    
                });
                }

            return View(model);
        }



        [HttpGet]
        public ActionResult Chart(int id)
        {



            var chmodel = new ChartModel();



            return View(chmodel);
        }

    }

}