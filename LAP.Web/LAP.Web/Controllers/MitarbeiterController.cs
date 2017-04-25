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


            List<companies> allCompanies = FirmenVerwaltung.GetCompanies();

            // VARIANTE user defined MAPPING
            // mapping von List<Company> auf List<CompanyModel>
            var model = new List<Models.FirmenModel>();

            foreach (var company in allCompanies)
            {
                model.Add(new Models.FirmenModel()
                {
                    ID = company.id,
                    Companyname = company.companyname,
                    Number = company.number,
                    Street = company.street,
                    Zip = company.zip,
                    City = company.city
                });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Stornierungen()
        {
            var bookingreversals = BuchungsVerwaltung.GetBookingReversals();
            var model = new List<StornoModel>();
            foreach (var b in bookingreversals)
            {
                model.Add(new StornoModel{
                    Reason = b.reason,
                    Benutzername = b.portalusers.email,
                    Date=b.bookings.date

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