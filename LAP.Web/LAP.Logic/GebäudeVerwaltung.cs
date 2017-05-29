using LAP.Logic;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LAP.Logic
{
    public class GebäudeVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Alle gebäude aus der DB
        /// </summary>
        /// <returns>ListGebäude</returns>
        public static List<Gebäude> GetGebäude()
        {
            log.Info("GetGebäude()");
            List<Gebäude> result = null;
            
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    result = context.AlleGebäude
                        .Include(x => x.Räume)
                        .Where(x => x.active)
                        .OrderBy(x => x.order)
                        .ToList();
                }
                catch (Exception ex)
                {
                    log.Error("Exception in GetGebäude", ex);
                    if (ex.InnerException != null)
                        log.Error("Exception in GetGebäude (inner)", ex.InnerException);
                    throw;
                }
            }

            return result;
        }
    }
}
