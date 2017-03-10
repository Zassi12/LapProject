using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Logic
{
    public enum LogonResult
    {
        LogonDataValid,
        LogonDataInvalid,
        UserInactive,
        UnkownUser,
    }

    public enum PasswordChangeResult
    {
        Success,
        UserInactive,
        UsernameInvalid,
        PasswortInvalid
    }

    public enum ProfileChangeResult
    {
        Success,
        UserInactive,
        UsernameInvalid
    }

    public class BenutzerVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// Returns succsess or not
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>Passwordchangeresult success</returns>
        public static PasswordChangeResult ChangePassword(string username, string oldPassword, string newPassword)
        {
            PasswordChangeResult result = PasswordChangeResult.UsernameInvalid;

            log.Info("ChangePassword(username, oldPassword, newPassword)");

            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));
            else if (string.IsNullOrEmpty(newPassword))
                throw new ArgumentNullException(nameof(newPassword));
            else if (string.IsNullOrEmpty(oldPassword))
                throw new ArgumentNullException(nameof(oldPassword));
            else
            {
                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portaluser curUser = context.Allportalusers.Where(x => x.email == username).FirstOrDefault();

                        if (curUser == null)
                        {
                            result = PasswordChangeResult.UsernameInvalid;
                        }
                        //else if (!curUser.Active)
                        //{
                        //    result = PasswordChangeResult.UserInactive;
                        //}
                        else if (!curUser.password.SequenceEqual(Tools.GetSHA2(oldPassword)))
                        {
                            result = PasswordChangeResult.PasswortInvalid;
                        }
                        else
                        {
                            log4net.LogicalThreadContext.Properties["idUser"] = curUser.id;

                            curUser.password = Tools.GetSHA2(newPassword);
                            context.SaveChanges();

                            result = PasswordChangeResult.Success;
                            log.Info("Changed password successfully!");
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Exception in ChangePassword", ex);
                        if (ex.InnerException != null)
                            log.Error("Exception in ChangePassword (inner)", ex.InnerException);
                        throw;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Saves new first- and lastname for the given userName
        /// </summary>
        /// <param name="username">the user to change data for</param>
        /// <param name="firstname">new firstname</param>
        /// <param name="lastname">new lastname</param>
        /// <returns><see cref="ProfileChangeResult"/> SUCCESS if information could be saved, otherelse corresponding error member</returns>
        /// <exception cref="Exception">in case saving information fails or unknown user</exception>
        /// <exception cref="ArgumentNullException">if user-, first- or lastname is null or empty</exception>
        public static ProfileChangeResult SaveProfileData(string username, string firstname, string lastname)
        {
            log.Info("SaveProfileData(username, firstname, lastname)");
            ProfileChangeResult result = ProfileChangeResult.UsernameInvalid;

            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException($"{nameof(username)} is null or empty");
            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentNullException($"{nameof(firstname)} is null or empty");
            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentNullException($"{nameof(lastname)} is null or empty");

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    portaluser currentUser = context.Allportalusers.FirstOrDefault(x => x.email == username);
                    if (currentUser != null)
                    {

                        currentUser.firstname = firstname;
                        currentUser.lastname = lastname;
                        context.SaveChanges();
                        log.Info("Profile Data changed successfully!");
                        result = ProfileChangeResult.Success;

                    }
                    else
                    {
                        log.Info("SaveProfileData - UsernameInvalid");
                        result = ProfileChangeResult.UsernameInvalid;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Exception in SaveProfileData", ex);
                    if (ex.InnerException != null)
                        log.Error("Exception in SaveProfileData (inner)", ex.InnerException);
                    throw;
                }
            }

            return result;
        }

        /// <summary>
        /// Liefert alle Kunden aus der DB
        /// </summary>
        /// <returns>Liste aller Kunden</returns>
        public static List<portaluser> AlleBenutzer()
        {
            var benutzerListe = new List<portaluser>();
            var context = new ITIN20LAPEntities();
            benutzerListe = context.Allportalusers.ToList();
            return benutzerListe;
        }

        public static portaluser GetUser(string username)
        {
            log.Info("GetUser(username)");

            portaluser user = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    user = context.Allportalusers.Where(x => x.email == username).FirstOrDefault();

                    if (user == null)
                    {
                        log.Info("Unknown username!");
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Exception in GetUser", ex);
                    if (ex.InnerException != null)
                        log.Error("Exception in GetUser (inner)", ex.InnerException);
                    throw;
                }
            }

            return user;
        }

        public static bool DeactivateUser(string username)
        {
            log.Info("DeactivateUser(username)");
            bool success = false;

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }
            else
            {
                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portaluser curUser = context.Allportalusers.Where(x => x.email == username).FirstOrDefault();

                        if (curUser != null)
                        {
                            curUser.active = false;
                            context.SaveChanges();
                            success = true;
                            log.Info("User has been deactivated!");
                        }
                        else
                        {
                            log.Info("Unknown username");
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Exception in DeactivateUser", ex);
                        if (ex.InnerException != null)
                            log.Error("Exception in DeactivateUser (inner)", ex.InnerException);
                        throw;
                    }
                }
            }
            return success;
        }
        public static bool ActivateUser(string username)
        {
            log.Info("ActivateUser(username)");
            bool success = false;

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }
            else
            {
                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portaluser curUser = context.Allportalusers.Where(x => x.email == username).FirstOrDefault();

                        if (curUser != null)
                        {
                            curUser.active = true;
                            context.SaveChanges();
                            success = true;
                            log.Info("User has been deactivated!");
                        }
                        else
                        {
                            log.Info("Unknown username");
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Exception in DeactivateUser", ex);
                        if (ex.InnerException != null)
                            log.Error("Exception in DeactivateUser (inner)", ex.InnerException);
                        throw;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Logon result as verification 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LogonResult Logon(string username, string password)
        {
            log.Info("Logon(username, password)");
            LogonResult result = LogonResult.LogonDataInvalid;
            

            if (string.IsNullOrEmpty(username))
            {
                log.Error("Username is empty!");
                throw new ArgumentNullException(nameof(username));
            }
            else if (string.IsNullOrEmpty(password))
            {
                log.Error("Password is empty!");
                throw new ArgumentNullException(nameof(password));
            }
            else
            {
                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portaluser user = context.Allportalusers.Where(x => x.email == username).FirstOrDefault();

                        if (user != null)
                        {
                            if (user.password.SequenceEqual(Tools.GetSHA2(password)))
                            {
                                log.Info("Logon data valid");
                                result = LogonResult.LogonDataValid;
                            }

                            else
                            {
                                log.Info("Logon data invalid");
                                result = LogonResult.LogonDataInvalid;
                            }

                            int anzahlZeilen = context.SaveChanges();
                        }
                        else
                        {
                            result = LogonResult.UnkownUser;
                            log.Info("Unknown username");
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Exception in Logon", ex);
                        if (ex.InnerException != null)
                            log.Error("Exception in Logon (inner)", ex.InnerException);
                        throw;
                    }
                }
            }
            return result;
        }

    }
}
