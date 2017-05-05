using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace LAP.Logic
{
    public class RolenVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Sucht Benutzer anhand der Rollen Namen
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns>list of portalusers</returns>
        public static List<Benutzer> GetRoleUsers(string roleName)
        {
            log.Info("GetRoleUsers(rolenName)");

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            else
            {
                List<Benutzer> roleUsers = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        BenutzerRollen aktRolle = context.AlleBenutzerRollen.Where(x => x.Beschreibung == roleName).FirstOrDefault();
                        if (aktRolle != null)
                        {
                            roleUsers = aktRolle.Benutzer.ToList();
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Exception in GetRoleUsers", ex);
                        if (ex.InnerException != null)
                            log.Error("Exception in GetRoleUsers (inner)", ex.InnerException);
                        throw;
                    }
                }

                return roleUsers;
            }
        }
        /// <summary>
        /// Sucht alle Rollen aus der Datenbank
        /// </summary>
        /// <returns>list of portalroles</returns>
        public static List<BenutzerRollen> GetRoles()
        {
            log.Info("GetRoles()");
            List<BenutzerRollen> rollen = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    rollen = context.AlleBenutzerRollen.ToList();
                }
                catch (Exception ex)
                {
                    log.Error("Exception in GetRoles", ex);
                    if (ex.InnerException != null)
                        log.Error("Exception in GetRoles (inner)", ex.InnerException);
                    throw;
                }
            }

            return rollen;
        }
        /// <summary>
        /// Sucht User anhand deren BenutzerName(Email)
        /// </summary>
        /// <param name="email"></param>
        /// <returns>portalrole object</returns>
        public static BenutzerRollen GetUserRole(string email)
        {
            log.Info("GetUserRoles(username)");

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            else
            {
                BenutzerRollen userRole = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        Benutzer aktBenutzer = context.AlleBenutzer.Where(x => x.Email == email).FirstOrDefault();
                        if (aktBenutzer != null)
                        {
                            userRole = aktBenutzer.BenutzerRollen;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Exception in GetUserRole", ex);
                        if (ex.InnerException != null)
                            log.Error("Exception in GetUserRole (inner)", ex.InnerException);
                        throw;
                    }
                }

                return userRole;
            }
        }
    }
}
