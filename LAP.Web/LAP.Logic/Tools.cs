using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Logic
{
    /// <summary>
    /// A class meant for general tools to help in all situations.
    /// </summary>
    public class Tools
    {
        private static readonly log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static byte[] GetSHA2(string plainText)
        {
            log.Info("GetSHA2(plainText)");
            byte[] hash = null;

            if (string.IsNullOrEmpty(plainText))
            {
                log.Error("Empty plainText");
                throw new ArgumentNullException(nameof(plainText));
            }
            else
            {
                SHA256 algo = SHA256.Create();
                byte[] plainTextBuffer = Encoding.UTF8.GetBytes(plainText);
                hash = algo.ComputeHash(plainTextBuffer);
            }

            return hash;
        }

        /// <summary>
        /// Prüft ob ein Benutzer ein Mitarbeiter ist, wenn ja gibt die Methode true, ansonsten false zurück
        /// </summary>
        /// <param name="email">Die Email-Adresse des zu prüfenden Benutzers</param>
        /// <returns>true oder false</returns>
        public static bool BistDuMitarbeiter(string email)
        {
            //Debug.WriteLine("Tools - Bist du Mitarbeiter");
            //Debug.Indent();

            //bool istMitarbeiter = false;

            //try
            //{
            //    using (var context = new ITIN20LAPEntities())
            //    {
            //        //Gibt es einen Benutzer, bei der die Email Adresse dem Parameter entspricht
            //        // UND das Feld Ist_Mitarbeiter TRUE ist
            //        istMitarbeiter = context.Allportalusers.Any(x => x.email == email);

            //        //List<portaluser> mitarbeiter = new List<portaluser>() { new portaluser { email = "dzallinger@gmx.at" } };
            //        foreach (var i in context.Allportalusers)
            //        {
            //            //foreach (var x in mitarbeiter)
            //            //{
            //                if (i.email == email)
            //                {
            //                    istMitarbeiter = true;
            //                }
            //            //}

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("Fehler beim Prüfen ob ein Benutzer ein Mitarbeiter ist");
            //    Debug.WriteLine(ex.Message);
            //    Debugger.Break();
            //}

            //Debug.Unindent();
            //return istMitarbeiter;
            return true;
        }

    }
}
