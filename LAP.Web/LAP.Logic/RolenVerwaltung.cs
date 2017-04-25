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
        public static List<portalusers> GetRoleUsers(string roleName)
        {
            log.Info("GetRoleUsers(rolenName)");

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            else
            {
                List<portalusers> roleUsers = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portalroles aktRolle = context.Allportalroles.Where(x => x.description == roleName).FirstOrDefault();
                        if (aktRolle != null)
                        {
                            roleUsers = aktRolle.portalusers.ToList();
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
        public static List<portalroles> GetRoles()
        {
            log.Info("GetRoles()");
            List<portalroles> rollen = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    rollen = context.Allportalroles.ToList();
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
        public static portalroles GetUserRole(string email)
        {
            log.Info("GetUserRoles(username)");

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            else
            {
                portalroles userRole = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portalusers aktBenutzer = context.Allportalusers.Where(x => x.email == email).FirstOrDefault();
                        if (aktBenutzer != null)
                        {
                            userRole = aktBenutzer.portalroles;
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
