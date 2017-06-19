using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.Web.Mvc;
using LAP.Web.Models;
using LAP.Logic;
using LAP.Web.App_Start;
using System.Web.Security;
using System.Text;

namespace LAP.Web.Controllers
{
    public class RaumController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        
        public ActionResult Index()
        {
            log.Info("GET - Room - Index");

            var räume = RaumVerwaltung.GetRäume();
            List<RaumModel> glist = new List<RaumModel>();

            foreach (var i in räume)
            {
                RaumModel model = new RaumModel();
                model.Id = i.Id;
                model.GebäudeBez = i.Gebäude.GebäudeBez;
                model.Hausnummer = i.Gebäude.Hausnummer;
                model.Plz = i.Gebäude.Plz;
                model.Stadt = i.Gebäude.Stadt;
                model.Straße = i.Gebäude.Straße;
                model.RaumBeschreibung = i.Bez;
                glist.Add(model);
            }
                        
            return View(glist);
        }

        public ActionResult RaumDetails(int id)
        {

            RaumModel model = new RaumModel();
            var raum = RaumVerwaltung.GetRaumId(id);
            model.GebäudeBez = raum.Gebäude.GebäudeBez;
            model.Hausnummer = raum.Gebäude.Hausnummer;
            model.Plz = raum.Gebäude.Plz;
            model.Stadt = raum.Gebäude.Stadt;
            model.Straße = raum.Gebäude.Straße;
            model.RaumBeschreibung = raum.Bez;
            //model.RaumEinrichtungen = raum.AlleRaumEinrichtungen;


            return View(model);
        }
        public ActionResult Chart(int id)
        {
            //var räume = RaumVerwaltung.GetAllRooms();
            //var buchungen = BuchungsVerwaltung.GetBookings();
            //var chartmodel = new ChartModel();

            //foreach (var item in räume)
            //{
            //    chartmodel.xaxis.Add(item.facilities.facilityname);
            //}
            //foreach (var item in buchungen)
            //{
            //    for (int i = 1; i == 5 ; i++)
            //    {
            //        if (item.room_id == i )
            //        {
            //            chartmodel.yaxis[i] = item.room_id;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }

                
            //}
               return View();
            
        }


    }
}