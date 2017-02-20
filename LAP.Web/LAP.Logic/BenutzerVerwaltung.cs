using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Logic
{
    public class BenutzerVerwaltung
    {

        /// <summary>
        /// Überprüft ob Anmeldedaten ok sind
        /// </summary>
        /// <param name="benutzerName">Die vergebene Email-Adresse</param>
        /// <param name="passwort">Das vergebene Passwort</param>
        /// <returns>true oder false</returns>
        public static bool Anmelden(string benutzerName, string passwort)
        {
            Debug.WriteLine("BenutzerVerwaltung - Anmelden");
            return Tools.PasswortUndEmailVergleich(benutzerName, passwort);
        }

        /// <summary>
        /// Liefert alle Kunden aus der DB
        /// </summary>
        /// <returns>Liste aller Kunden</returns>
        public static List<portaluser> AlleBenutzer()
        {
            var benutzerListe = new List<portaluser>();
            var context = new ITIN20LAPEntities();
            benutzerListe = context.portalusers.ToList();
            return benutzerListe;
        }

        /// <summary>
        /// Sucht den Benutzer anhand seiner Email aus der DB 
        /// </summary>
        /// <param name="email">die Email des gesuchten Benutzers</param>
        /// <returns>den Benutzer oder NULL kein benutzer gefunden wird oder bei Fehler</returns>
        public static portaluser BenutzerSuchen(string email)
        {
            Debug.WriteLine("BenutzerVerwaltung - BenutzerSuche(email)");
            Debug.Indent();
            portaluser gesuchterBenutzer = null;
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    gesuchterBenutzer = context.portalusers.Where(x => x.email == email).FirstOrDefault();
                    int id = gesuchterBenutzer.id;
                    gesuchterBenutzer = context.portalusers.Find(id);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Fehler beim Suchen des Benutzers");
                    Debug.WriteLine(ex.Message);
                    Debugger.Break();
                }
            }
            Debug.Unindent();
            return gesuchterBenutzer;
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
                    gesuchterBenutzer = context.portalusers.Where(x => x.id == benutzer.id).FirstOrDefault();
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
    }
}
