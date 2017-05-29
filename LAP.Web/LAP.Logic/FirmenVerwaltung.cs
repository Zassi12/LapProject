
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Entity;


namespace LAP.Logic
{
    public class FirmenVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// returns a list of all companies
        /// </summary>
        /// <exception cref="Exception">if database access fails</exception>
        /// <returns>list of all active companies</returns>
        public static List<Firma> GetAlleFirmen()
        {
            log.Info("HoleFirma(id)");
            List<Firma> allCompanies = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allCompanies = context.AlleFirmen.Include("AlleKontakte").ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetAlleFirmen", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetAlleFirmen (inner)", ex.InnerException);
                throw;
            }

            return allCompanies;
        }

        /// <summary>
        /// returns company with the given id
        /// </summary>
        /// <param name="id">the id to look up for</param>
        /// <returns>company with given id or null in case of an erro</returns>
        /// <exception cref="ArgumentException">in case of an invalid id</exception>
        public static Firma GetFirma(int id)
        {
            log.Info("GetFirma(id)");

            if (id <= 0)
                throw new ArgumentException("Invalid value for id", nameof(id));
            else
            {
                Firma company = null;

                try
                {
                    using (var context = new ITIN20LAPEntities())
                    {
                        company = context.AlleFirmen.FirstOrDefault(x => x.Id == id);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Exception in GetFirma", ex);
                    if (ex.InnerException != null)
                        log.Error("Exception in GetFirma (inner)", ex.InnerException);
                    throw;
                }

                return company;
            }
        }

        /// <summary>
        /// Alle Firmen Käufe
        /// </summary>
        /// <returns></returns>
        public static int GetCompanySales()
        {
            int sales = 0;
            Random rnd = new Random();
            sales = rnd.Next(300, 7300);
            return sales;
        }

    }
}
