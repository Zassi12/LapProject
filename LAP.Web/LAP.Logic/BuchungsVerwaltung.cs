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


        public static List<bookingreversals> GetBookingReversals()
        {


            List<bookingreversals> allBookingreversals = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allBookingreversals = context.Allbookingreversals.Include("portalusers").Include("bookings").ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetCompanies", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetCompanies (inner)", ex.InnerException);
                throw;
            }

            return allBookingreversals;
        }

        /// <summary>
        /// all booking reverslas by this date and younger
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<bookingreversals> GetBookingReversals(DateTime date)
        {


            List<bookingreversals> bookingreversalsbydate = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    context.Allbookings.Where(t =>
                    t.date >= t.date.AddMonths(-1)
                    ).ToList();



                    bookingreversalsbydate = context.Allbookingreversals.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetCompanies", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetCompanies (inner)", ex.InnerException);
                throw;
            }

            return bookingreversalsbydate;
        }

        public static List<bookings> GetBookings()
        {
            List<bookings> bookings = new List<bookings>();

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    context.Allbookings.ToList();

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
