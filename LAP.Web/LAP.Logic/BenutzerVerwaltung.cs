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
        public static List<Benutzer> AlleBenutzer()
        {
            List<Benutzer> benutzerListe = new List<Benutzer>();
            var context = new ITIN20LAPEntities();
            benutzerListe = context.portalusers.ToList();
            return benutzerListe;
        }

        /// <summary>
        /// Sucht den Benutzer anhand seiner Email aus der DB 
        /// </summary>
        /// <param name="email">die Email des gesuchten Benutzers</param>
        /// <returns>den Benutzer oder NULL kein benutzer gefunden wird oder bei Fehler</returns>
        public static Benutzer BenutzerSuchen(string email)
        {
            Debug.WriteLine("BenutzerVerwaltung - BenutzerSuche(email)");
            Debug.Indent();
            Benutzer gesuchterBenutzer = null;
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    gesuchterBenutzer = context.AlleBenutzer.Where(x => x.Email == email).FirstOrDefault();
                    int id = gesuchterBenutzer.ID;
                    gesuchterBenutzer = context.AlleBenutzer.Find(id);
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

        /// <summary>
        /// Speichert das übergebene Objekt in die Datenbank
        /// </summary>
        /// <param name="benutzer">das Datenbankobjekt Benutzer</param>
        /// <returns>die Anzahl der betroffenen Zeilen</returns>
        public static int Aktualisieren(Benutzer benutzer)
        {
            Debug.WriteLine("BenutzerVerwaltung - Aktualisieren(id)");
            Debug.Indent();
            int zeilen = 0;
            Benutzer gesuchterBenutzer = null;
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    gesuchterBenutzer = context.AlleBenutzer.Where(x => x.ID == benutzer.ID).FirstOrDefault();
                    gesuchterBenutzer.Nachname = benutzer.Nachname;
                    gesuchterBenutzer.ID = benutzer.ID;
                    gesuchterBenutzer.Geburtsdatum = benutzer.Geburtsdatum;
                    gesuchterBenutzer.Vorname = benutzer.Vorname;
                    gesuchterBenutzer.Land = benutzer.Land;
                    gesuchterBenutzer.Passwort = benutzer.Passwort;
                    gesuchterBenutzer.Telefon = benutzer.Telefon;
                    gesuchterBenutzer.Titel = benutzer.Titel;
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


        public partial class Benutzer
        {
            public Benutzer()
            {
                this.AlleBuchungen = new HashSet<Buchung>();
            }

            public int ID { get; set; }
            public string Email { get; set; }
            public byte[] Passwort { get; set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public bool Geschlecht { get; set; }
            public string Telefon { get; set; }
            public string Titel { get; set; }
            public System.DateTime Geburtsdatum { get; set; }
            public bool Ist_Mitarbeiter { get; set; }
            public System.DateTime ErstelltAm { get; set; }

            public virtual Adresse Adresse { get; set; }
            public virtual Land Land { get; set; }
            public virtual ICollection<Buchung> AlleBuchungen { get; set; }
        }

    }
}
