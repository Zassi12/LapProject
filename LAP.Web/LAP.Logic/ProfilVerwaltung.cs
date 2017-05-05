using log4net;
using System;
using System.Linq;

namespace LAP.Logic
{
    public class ProfilVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Benutzer GetProfileData(int id)
        {
           Benutzer puser = null;
           
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    puser = context.AlleBenutzer.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetProfileData", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetProfileData (inner)", ex.InnerException);
                throw;
            }

            return puser;
        }

        public Benutzer GetProfileData(string email)
        {
            Benutzer puser = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    puser = context.AlleBenutzer.Include("Rechnungen").Include("Stornierungen").Include("Buchungen").Include("Kontakte").Include("BenutzerRollen").Include("Firmen").FirstOrDefault(x => x.Email == email);
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetProfileData", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetProfileData (inner)", ex.InnerException);
                throw;
            }

            return puser;
        }



    }
}
