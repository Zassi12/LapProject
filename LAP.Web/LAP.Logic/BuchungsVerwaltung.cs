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


        public static List<bookingreversal> GetBookingReversals()
        {


            List<bookingreversal> allBookingreversals = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allBookingreversals = context.AllBookingreversals.ToList();
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
        public static List<bookingreversal> GetBookingReversals(DateTime date)
        {


            List<bookingreversal> bookingreversalsbydate = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    context.bookings.Where(t =>
                    t.date >= t.date.AddMonths(-1)
                    ).ToList();
                    

                    
                    bookingreversalsbydate = context.AllBookingreversals.ToList();
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
    }
}
