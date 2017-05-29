using System.Data.Entity;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Logic
{
    public class RechnungsVerwaltung
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static Rechnung RechnungErstellen(string user)
        {

            if (string.IsNullOrEmpty(user))
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                Rechnung rechnung = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        rechnung = context.AlleRechnungen
                            .Include(x => x.Benutzer)
                            .Include(x => x.AlleRechnungsDetails)
                            .Include(x => x.Benutzer.AlleStornierungen)
                            /*.Where(x => x.Benutzer.Email == user)*/.FirstOrDefault();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                return rechnung;
            }
        }
    }
}
