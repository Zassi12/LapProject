using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace LAP.Logic
{
    public class BenutzerVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Überprüft ob Anmeldedaten ok sind
        /// </summary>
        /// <param name="benutzerName">Die vergebene Email-Adresse</param>
        /// <param name="passwort">Das vergebene Passwort</param>
        /// <returns>true oder false</returns>
        //public static bool Anmelden(string benutzerName, string passwort)
        //{
        //    Debug.WriteLine("BenutzerVerwaltung - Anmelden");
        //    return Tools.PasswortUndEmailVergleich(benutzerName, passwort);
        //}

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

        ///// <summary>
        ///// Speichert das übergebene Objekt in die Datenbank
        ///// </summary>
        ///// <param name="benutzer">das Datenbankobjekt Benutzer</param>
        ///// <returns>die Anzahl der betroffenen Zeilen</returns>
        public static int Aktualisieren(portaluser benutzer)
        {
            Debug.WriteLine("BenutzerVerwaltung - Aktualisieren(id)");
            Debug.Indent();
            int zeilen = 0;
            portaluser gesuchterBenutzer = null;
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    gesuchterBenutzer = context.Allportalusers.Where(x => x.id == benutzer.id).FirstOrDefault();
                    gesuchterBenutzer.id = benutzer.id;
                    gesuchterBenutzer.password = benutzer.password;
                    zeilen = context.SaveChanges();
                    Debug.WriteLineIf(zeilen == 1, "Benutzer erfolgreich geändert!");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Fehler beim Aktualisieren des Benutzers");
                    Debug.WriteLine(ex.Message);
                    Debugger.Break();
                }
            }
            Debug.Unindent();
            return zeilen;

        }
        /// <summary>
        /// Fügt einen user der datenbank hinzu
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Hinzufügen(portaluser user)
        {
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return 1;
            }
        }

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
