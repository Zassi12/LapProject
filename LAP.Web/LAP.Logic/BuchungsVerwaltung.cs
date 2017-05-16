using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace LAP.Logic
{
    public class BuchungsVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static List<Stornierung> AlleStornierungen()
        {
            List<Stornierung> stornos = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    //stornos = context.AlleStornierungen.Include("Benutzer").Include("Buchungen").ToList();
                    stornos = context.AlleStornierungen
                        .Include(x => x.Benutzer)
                        .Include(x => x.Benutzer.Firma)
                        .Include(x => x.Buchung)
                        .Include(x => x.Buchung.Räume)
                        .ToList();
                }                
            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleStornierungen", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleStornierungen (inner)", ex.InnerException);
                throw;
            }

            return stornos;
        }

        /// <summary>
        /// all booking reverslas by this date and younger
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Stornierung> AlleStornierungenDatum(DateTime datum)
        {


            List< Stornierung> Stornobydate = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    Stornobydate = context.AlleStornierungen.Include("Benutzer").Include("Buchungen").Where(x=>(x.Buchung.Datum==datum)).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleStornierungenDatum", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleStornierungenDatum (inner)", ex.InnerException);
                throw;
            }

            return Stornobydate;
        }

        public static List<Buchung> AlleBuchungen()
        {
            List<Buchung> bookings = new List<Buchung>();

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    context.AlleBuchungen.ToList();

                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleBuchungen", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleBuchungen (inner)", ex.InnerException);
                throw;
            }
            return bookings;

        }

    }

}
