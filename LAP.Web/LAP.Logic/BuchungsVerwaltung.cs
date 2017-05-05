using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LAP.Logic
{
    public class BuchungsVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static List<Stornierungen> GetBookingReversals()
        {


            List<Stornierungen> stornos = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    stornos = context.AlleStornierungen.Include("Benutzer").Include("Buchungen").ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetCompanies", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetCompanies (inner)", ex.InnerException);
                throw;
            }

            return stornos;
        }

        /// <summary>
        /// all booking reverslas by this date and younger
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Stornierungen> GetBookingReversals(DateTime date)
        {


            List< Stornierungen> Stornobydate = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    Stornobydate = context.AlleStornierungen.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetCompanies", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetCompanies (inner)", ex.InnerException);
                throw;
            }

            return Stornobydate;
        }

        public static List<Buchungen> GetBookings()
        {
            List<Buchungen> bookings = new List<Buchungen>();

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    context.AlleBuchungen.ToList();

                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetCompanies", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetCompanies (inner)", ex.InnerException);
                throw;
            }
            return bookings;

        }

    }

}
