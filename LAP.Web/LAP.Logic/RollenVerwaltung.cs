using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace LAP.Logic
{
    public class RollenVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Sucht Benutzer anhand der Rollen Namen
        /// </summary>
        /// <param name="rollenName"></param>
        /// <returns>list of portalusers</returns>
        public static List<Benutzer> ErmittleRollenBenutzer(string rollenName)
        {
            log.Info("ErmittleRollenBenutzer(rolenName)");

            if (string.IsNullOrEmpty(rollenName))
            {
                throw new ArgumentNullException(nameof(rollenName));
            }
            else
            {
                List<Benutzer> roleUsers = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        BenutzerRolle aktRolle = context.AlleBenutzerRollen.Where(x => x.Beschreibung == rollenName).FirstOrDefault();
                        if (aktRolle != null)
                        {
                            roleUsers = aktRolle.AlleBenutzer.ToList();
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
        public static List<BenutzerRolle> ErmittleRollen()
        {
            log.Info("GetRoles()");
            List<BenutzerRolle> rollen = null;

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
        public static BenutzerRolle ErmittleBenutzerRolle(string email)
        {
            log.Info("GetUserRoles(username)");

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            else
            {
                BenutzerRolle userRole = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        Benutzer aktBenutzer = context.AlleBenutzer.Where(x => x.Email == email).FirstOrDefault();
                        if (aktBenutzer != null)
                        {
                            userRole = aktBenutzer.BenutzerRolle;
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
