
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;


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
        public static List<company> GetCompanies()
        {

            List<company> allCompanies = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allCompanies = context.AllCompanies.Include("contacts").ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetCompanies", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetCompanies (inner)", ex.InnerException);
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
        public static company GetCompany(int id)
        {
            log.Info("GetCompany(id)");

            if (id <= 0)
                throw new ArgumentException("Invalid value for id", nameof(id));
            else
            {
                company company = null;

                try
                {
                    using (var context = new ITIN20LAPEntities())
                    {
                        company = context.AllCompanies.FirstOrDefault(x => x.id == id);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Exception in GetCompany", ex);
                    if (ex.InnerException != null)
                        log.Error("Exception in GetCompany (inner)", ex.InnerException);
                    throw;
                }

                return company;
            }
        }

        public static int GetCompanySales()
        {
            int sales = 0;
            Random rnd = new Random();
            sales = rnd.Next(300, 7300);
            return sales;
        }

    }
}
