using log4net;
using System;
using System.Linq;

namespace LAP.Logic
{
    public class ProfilVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public portaluser GetProfileData(int id)
        {
           portaluser puser = null;
           
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    puser = context.Allportalusers.FirstOrDefault(x => x.id == id);
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

        public portaluser GetProfileData(string email)
        {
            portaluser puser = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    puser = context.Allportalusers.Include("bills").Include("bookingreversals").Include("bookings").Include("contacts").Include("portalrole").FirstOrDefault(x => x.email == email);
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
