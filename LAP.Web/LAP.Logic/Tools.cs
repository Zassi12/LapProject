using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using iTextSharp.text.pdf;
using System.Data;
using iTextSharp.text.pdf.parser;
using System.util.collections;
using iTextSharp.text;
using System.Net.Mail;

namespace LAP.Logic
{
    /// <summary>
    /// A class meant for general tools to help in all situations.
    /// </summary>
    public class Tools
    {
        private static readonly log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// SHA512 Algorythmus Hash
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static byte[] GetSHA512(string plainText)
        {
            log.Info("GetSHA512(plainText)");
            byte[] hash = null;
            try
            {
                if (string.IsNullOrEmpty(plainText))
                {
                    log.Error("Empty plainText");
                    throw new ArgumentNullException(nameof(plainText));
                }
                else
                {
                    SHA512 algo = SHA512.Create();
                    byte[] plainTextBuffer = Encoding.UTF8.GetBytes(plainText);
                    hash = algo.ComputeHash(plainTextBuffer);
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in GetSHA512", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in GetSHA512 (inner)", ex.InnerException);
                throw;
            }

            return hash;
        }

        public string Uid()
        {
            Random rng = new Random();
           string rnd =  "ATU"+rng.Next(14153222, 19341321);
            return rnd;
        }
        public string FNumber()
        {
            Random rng = new Random();
            string rnd = ""+ rng.Next(14153, 19341);
            return rnd;
        }

        private void SendEmail(MemoryStream ms)
        {
            MailAddress _From = new MailAddress("dzallinger@gmx.at");
            MailAddress _To = new MailAddress("dzallinger@gmx.at");
            MailMessage email = new MailMessage(_From, _To);
            Attachment attach = new Attachment(ms, new System.Net.Mime.ContentType("application/pdf"));
            email.Attachments.Add(attach);
            SmtpClient mailSender = new SmtpClient("srv08.itccn.loc");
            mailSender.Send(email);

        }


        public string GetCsv()
        {



            return null;
        }
        public Pdf Pdftemplate(int id, string email)
        {
            Benutzer benutzer = BenutzerVerwaltung.getBenutzer(email);
            Rechnung r = RechnungsVerwaltung.RechnungErstellen(email);
            Benutzer b = BenutzerVerwaltung.getBenutzer("edruckner@gmx.at");

            Pdf pdf = new Logic.Pdf();
            pdf.Zeile = "                                                                  ";
            pdf.Absender = string.Format("AbsenderAddresse:\nVorname:{0}\nNachname:{1}\nOrt:{2}\nPlz:{3}\nUidAbsender:{4}", b.Vorname, b.Nachname, b.Firma.Stadt, b.Firma.Plz, "ATU99999999");
            pdf.Empfänger = string.Format("EmpfängerAddresse:\nVorname:{0}\nNachname:{1}\nOrt:{2}\nPlz:{3}\nUidEmpfänger:{4}", r.Benutzer.Vorname, r.Benutzer.Nachname, r.Benutzer.Firma.Stadt, r.Benutzer.Firma.Plz, "ATU11111111");
            pdf.Artikel = string.Format("ArtikelBeschreibung:\nBezeichung:{0}\nMenge:{1}","Mietung eines Raumes", 1);
            pdf.Zeitraum = string.Format("Zeit der Buchung:{0}", r.Datum);
            pdf.ZuZahlenderBetrag = string.Format("€:{0}", 300);
            pdf.AustellungsDatum = string.Format("LieferDatum:{0}", r.Datum.AddDays(1));
            pdf.FortlaufendeNummer = string.Format("FortlaufendeNummer:{0}", FNumber());
            pdf.UID = string.Format("UID:{0}", Uid());


            return pdf;
        }





    }
    public class Pdf
    {
        public string Absender { get; set; }
        public string Empfänger { get; set; }
        public string Artikel { get; set; }
        public string Zeitraum { get; set; }
        public string ZuZahlenderBetrag { get; set; }
        public string AustellungsDatum { get; set; }
        public string FortlaufendeNummer { get; set; }
        public string UID { get; set; }
        public string Zeile { get; set; }

    }
}
