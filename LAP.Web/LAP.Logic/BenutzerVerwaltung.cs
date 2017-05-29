using LAP.Logic;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;



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
                        Benutzer curUser = context.AlleBenutzer.Where(x => x.Email == username).FirstOrDefault();

                        if (curUser == null)
                        {
                            result = PasswordChangeResult.UsernameInvalid;
                        }
                        else if (!curUser.active)
                        {
                            result = PasswordChangeResult.UserInactive;
                        }
                        else if (!curUser.Passwort.SequenceEqual(Tools.GetSHA512(oldPassword)))
                        {
                            result = PasswordChangeResult.PasswortInvalid;
                        }
                        else
                        {
                            log4net.LogicalThreadContext.Properties["idUser"] = curUser.Id;

                            curUser.Passwort = Tools.GetSHA512(newPassword);
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
                    Benutzer currentUser = context.AlleBenutzer.FirstOrDefault(x => x.Email == username);
                    if (currentUser != null)
                    {

                        currentUser.Vorname = firstname;
                        currentUser.Nachname = lastname;
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
        public static List<Benutzer> AlleBenutzer()
        {
            var benutzerListe = new List<Benutzer>();
            var context = new ITIN20LAPEntities();
            benutzerListe = context.AlleBenutzer.ToList();
            return benutzerListe;
        }

        public static Benutzer getBenutzer(string benutzer)
        {
            log.Info("GetUser(username)");

            Benutzer user = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    user = context.AlleBenutzer.Where(x => x.Email == benutzer).FirstOrDefault();

                    if (user == null)
                    {
                        log.Info("Unbekanter Benutzer!");
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

        public static bool BenutzerDeaktivieren(string username)
        {
            log.Info("BenutzerDeaktivieren(username)");
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
                        Benutzer curUser = context.AlleBenutzer.Where(x => x.Email == username).FirstOrDefault();

                        if (curUser != null)
                        {
                            curUser.active = false;
                            context.SaveChanges();
                            success = true;
                            log.Info("Benutzer wurde Deaktiviert!");
                        }
                        else
                        {
                            log.Info("Unbekannter Benutzer");
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Exception in BenutzerDeaktivieren", ex);
                        if (ex.InnerException != null)
                            log.Error("Exception in BenutzerDeaktivieren (inner)", ex.InnerException);
                        throw;
                    }
                }
            }
            return success;
        }
        public static bool BenutzerAktivieren(string username)
        {
            log.Info("BenutzerAktivieren(username)");
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
                        Benutzer curUser = context.AlleBenutzer.Where(x => x.Email == username).FirstOrDefault();

                        if (curUser != null)
                        {
                            curUser.active = true;
                            context.SaveChanges();
                            success = true;
                            log.Info("Benutzer wurde Aktiviert!");
                        }
                        else
                        {
                            log.Info("Unbekanter Benutzer");
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Exception in BenutzerAktivieren", ex);
                        if (ex.InnerException != null)
                            log.Error("Exception in BenutzerAktivieren (inner)", ex.InnerException);
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
                        Benutzer user = context.AlleBenutzer.Where(x => x.Email == username).FirstOrDefault();

                        if (user != null)
                        {
                            if (user.Passwort.SequenceEqual(Tools.GetSHA512(password)))
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
