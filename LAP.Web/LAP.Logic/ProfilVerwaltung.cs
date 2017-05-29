using log4net;
using System;
using System.Linq;
using System.Data.Entity;

namespace LAP.Logic
{
    public class ProfilVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Alle Benutzer per Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Benutzer GetProfilDatenId(int id)
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
                log.Error("Exception in GetProfilDatenId", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetProfilDatenId (inner)", ex.InnerException);
                throw;
            }

            return puser;
        }
        /// <summary>
        /// Alle Benutzer aus der db per Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Benutzer GetProfileDataEmail(string email)
        {
            Benutzer puser = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    puser = context.AlleBenutzer
                        .Include(x => x.AlleRechnungen)
                        .Include(x => x.AlleStornierungen)
                        .Include(x => x.AlleBuchungen)
                        .Include(x => x.AlleKontakte)
                        .Include(x => x.BenutzerRolle/*"BenutzerRollen"*/)
                        .Include(x => x.Firma/*"Firmen"*/)
                        .FirstOrDefault(x => x.Email == email);
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetProfileDataEmail", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetProfileDataEmail (inner)", ex.InnerException);
                throw;
            }

            return puser;
        }



    }
}
