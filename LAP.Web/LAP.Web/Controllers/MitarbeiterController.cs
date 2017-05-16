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
                    Companyname = company.FirmenName,
                    Number = company.Hausnummer,
                    Street = company.Straße,
                    Zip = company.Plz,
                    City = company.Stadt
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
                    Reason = b.Grund,
                    Benutzername = b.Benutzer.Email,
                    Date=b.Buchung.Datum,
                     Building = b.Buchung.Räume.Gebäude.Hausnummer,
                     //Room = b.Buchungen.Räume.Beschreibung,
                     //Firma = b.Buchungen.Benutzer.Firmen.FirmenName,
                     //User = b.Benutzer

                    
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