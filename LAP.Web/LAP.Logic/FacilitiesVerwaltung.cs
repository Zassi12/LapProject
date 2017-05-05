using LAP.Logic;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Logic
{
    public class FacilitiesVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static List<Gebäude> GetBuildings()
        {
            log.Info("GetBuildings()");
            List<Gebäude> result = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    result = context.AlleGebäude.Where(x => x.active).OrderBy(x => x.order).ToList();
                }
                catch (Exception ex)
                {
                    log.Error("Exception in GetBuildings", ex);
                    if (ex.InnerException != null)
                        log.Error("Exception in GetBuildings (inner)", ex.InnerException);
                    throw;
                }
            }

            return result;
        }
    }
}
