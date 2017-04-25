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

        [HttpGet]
        public ActionResult Index()
        {
            //log.Info("GET - Room - Index");
            //RaumFilterModel model = new Models.RaumFilterModel();
            //model.Buildings = FacilitiesVerwaltung.GetFacilities();

            //// get all buildings
            //List<facilities> facilities = FacilitiesVerwaltung.GetFacilities();
            //model.Buildings = AutoMapperConfig.CommonMapper.Map<List<FacilitiesModel>>(facilities);
            //List<companies> Firmen = FirmenVerwaltung.GetCompanies();
            //model.Facilities = AutoMapperConfig.CommonMapper.Map<List<FirmenModel>>(Firmen);

            return View();
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