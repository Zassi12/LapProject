using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using log4net;

namespace LAP.Logic
{
    public class ChartVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<Buchung> BeliebtesteRäume(DateTime DatumStart, DateTime DatumEnde) {

            List<Buchung> gebäude = null;
            DateTime date = DateTime.Parse("21.06.2017 15:14:31");
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    gebäude = context.AlleBuchungen
                        .Include(x => x.Räume)
                        .Include(x => x.Räume.Gebäude)
                        .Where(x => (x.Datum >= DatumStart&&date  <= DatumEnde))
                        .ToList();
                }

            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleStornierungenDatum", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleStornierungenDatum (inner)", ex.InnerException);
                throw;
            }

            return gebäude;
        }


    }
}
