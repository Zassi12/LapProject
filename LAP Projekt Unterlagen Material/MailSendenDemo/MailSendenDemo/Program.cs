using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSendenDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // erstelle die Mail-Nachricht
                string from = "onkelz-2000@hotmail.de";
                string to = "onkelz-2000@hotmail.de";
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "Stornierungen Februar";
                mail.Body = "Booking_ID	Portaluser_ID	PortaluserName	Reason\n1   1   Zallinger Fehlbuchung\n2   2   Bichler Fehlbuchung\n3   2   Bichler Fehlbuchung\n4   2   Bichler Fehlbuchung\n5   3   Druckner Fehlbuchung";

                // erstelle den SMTP Client
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = "srv08.itccn.loc";
                // username üblicherweise VORNAME.NACHNAME@qualifizierung.or.at
                string username = "maximilian.bichler@qualifizierung.or.at";
                // bitte IHR PASSWORT eintragen
                string password = "123user!";
                client.Credentials = new NetworkCredential(username, password);

                // sende alles ab
                client.Send(mail);

                Console.WriteLine("Mail wurde versendet!");
            }
            catch (SmtpException  ex)
            {
                Console.WriteLine("Fehler beim Mail-Versand");
                Debug.WriteLine(ex.StatusCode);
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }
        }
    }
}
