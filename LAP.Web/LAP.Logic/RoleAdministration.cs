using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace LAP.Logic
{
    public class RoleAdministration
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<portaluser> GetRoleUsers(string roleName)
        {
            log.Info("GetRoleUsers(rolenName)");

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            else
            {
                List<portaluser> roleUsers = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portalrole aktRolle = context.Allportalroles.Where(x => x.description == roleName).FirstOrDefault();
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

        public static List<portalrole> GetRoles()
        {
            log.Info("GetRoles()");
            List<portalrole> rollen = null;

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

        public static portalrole GetUserRole(string email)
        {
            log.Info("GetUserRoles(username)");

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            else
            {
                portalrole userRole = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portaluser aktBenutzer = context.Allportalusers.Where(x => x.email == email).FirstOrDefault();
                        if (aktBenutzer != null)
                        {
                            userRole = aktBenutzer.portalrole;
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
