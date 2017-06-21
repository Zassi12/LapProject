using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAP.Web.Models;
using LAP.Logic;
using LAP.Auth;
using System.Diagnostics;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using LAP.Web.App_Start;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LAP.Web.Controllers
{
    public class BenutzerController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Login-Seite, zu der mittels Formular die Logindaten
        /// eines Benutzer geschickt werden. Hier wird auch überprüft, ob der Benutzer ein Mitarbeiter ist, oder nicht
        /// </summary>
        /// <param name="lm">Das LoginModel, das Benutzername enthält</param>
        /// <returns>Bei erfolgreichem Login wird der Benutzer dahingeleitet, wo er herkommt</returns>
        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
            var logval = BenutzerVerwaltung.Logon(lm.Email, lm.Passwort);
            if (logval == LogonResult.LogonDataValid)
            {
                if (lm.AngemeldetBleiben)
                {
                    FormsAuthentication.SetAuthCookie(lm.Email, true);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(lm.Email, false);
                }

                ////wenn der User nicht von Benutzer/Verwaltung kommt leite ihn dahin weiter woher er kam
                //if (!Request.UrlReferrer.AbsoluteUri.Contains("Benutzer/ProfilAnsicht"))
                //{
                //    return Redirect(Request.UrlReferrer.AbsoluteUri);
                //}

                BenutzerRolle userRolle = RollenVerwaltung.ErmittleBenutzerRolle(lm.Email);

                if (userRolle != null && userRolle.Id == BenutzerRolle.MITARBEITER || userRolle.Id == BenutzerRolle.ADMINISTRATOR)
                {
                    TempData["erfolg"] = "Erfolgreich als Admin angemeldet!";
                    return RedirectToAction("Index", "Mitarbeiter");
                }
                else
                {
                    TempData["erfolg"] = "Erfolgreich angemeldet!";
                    return RedirectToAction("ProfilAnsicht", "Benutzer");
                }
            }
            else
            {
                TempData["fehler"] = "Konnte nicht Anmelden!";
            }

            return RedirectToAction("Login", "Benutzer");
        }


        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            TempData["erfolg"] = "Erfolgreich abgemeldet!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult ProfilAnsicht()
        {
            /// nimm den Benutzernamen 
            /// gehe damit in über die Logic in die DB
            /// hole dort alle Daten raus
            /// und gib sie in ein ProfilModel Objekt


            string benutzerName = User.Identity.Name;

            var benutzer = BenutzerVerwaltung.getBenutzer(benutzerName);

            //var user = AutoMapperConfig.CommonMapper.Map<ProfilDatenModel>(BenutzerVerwaltung.getBenutzer(benutzerName));

            var b = new ProfilDatenModel();
            b.ID = benutzer.Id;
            b.Active = benutzer.active;
            b.Email = benutzer.Email;
            b.Nachname = benutzer.Nachname;
            b.Vorname = benutzer.Vorname;
            //b.Passwort = benutzer.Passwort;
            return View(b);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ProfilAnsicht(ProfilDatenModel model)
        {
            //if (ModelState.IsValid)
            //{



            try
            {
                var profilsave = BenutzerVerwaltung.SaveProfileData(model.Email, model.Vorname, model.Nachname);
                if (profilsave == ProfileChangeResult.Success)
                {
                    TempData["erfolg"] = "Profil erfolgreich aktualisiert!";
                }
                else
                {
                    TempData["fehler"] = "Profil-Daten ungültig!";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            /// nimm die werte aus dem model (von der Oberfläche)
            /// und übergib sie der logik zum speichern der Daten in der Datenbank


            /// wenn speichern erfolgreich 




            //}
            //else
            //{
            //    TempData["fehler"] = "Profil-Daten ungültig!";

            //}


            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Buchen()
        {
            List<Buchung> Buchungen = BuchungsVerwaltung.AlleBuchungenUser(BenutzerVerwaltung.getBenutzer(User.Identity.Name));
            List<RaumBuchungsModel> model = new List<RaumBuchungsModel>();

            foreach (var i in Buchungen)
            {
                RaumBuchungsModel raum = new RaumBuchungsModel();
                raum.Id = i.Raum_Id;
                raum.Vorname = i.Benutzer.Vorname;
                raum.Nachname = i.Benutzer.Nachname;
                raum.StartDatum = i.Datum;
                raum.RaumBezeichung = i.Räume.Bez;
                raum.GebäudeBezeichnung = i.Räume.Gebäude.GebäudeBez;
                raum.Plz = i.Räume.Gebäude.Plz;
                model.Add(raum);
            }


            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult RechnungAnzeigen()
        {

            Rechnung rechnung = RechnungsVerwaltung.RechnungErstellen(User.Identity.Name);
            RechnungModel model = new RechnungModel();
            model.Absender = new Benutzer();
            model.Id = rechnung.Id;
            model.Absender.Vorname = rechnung.Benutzer.Vorname;
            model.Absender.Nachname = rechnung.Benutzer.Nachname;
            model.Absender.Email = rechnung.Benutzer.Email;
            model.Empfänger = new Benutzer();
            model.Empfänger.Vorname = rechnung.Benutzer.Vorname;
            model.Empfänger.Nachname = rechnung.Benutzer.Nachname;
            model.Empfänger.Email = rechnung.Benutzer.Email;
            model.LieferDatum = rechnung.Datum;
            model.AustellungsDatum = rechnung.Datum.AddDays(7);
            model.Bezeichnung = "Mieten Von Raum";
            model.Betrag = 1;
            model.Ust = 20;
            int betrag = 300;
            model.ZuZahlenderBetrag = string.Format("{0}{1}", betrag, "€");
            model.UidLiefernder = "ATU99999999";
            model.UidEmpfänger = "ATU11111111";
            model.RechnungsNummer = 1;


            return View(model);
        }


        [HttpGet]
        [Authorize]
        public ActionResult RechnungPdfAnzeigen()
        {
            string path = @"C:\Users\zalldani\Documents\Rechnung.pdf";
            Tools tools = new Tools();
            var benutzer = BenutzerVerwaltung.getBenutzer(User.Identity.Name);
            var pdf = tools.Pdftemplate(benutzer.Id,User.Identity.Name);


            Rechnung rechnung = RechnungsVerwaltung.RechnungErstellen(User.Identity.Name);
            RechnungModel model = new RechnungModel();
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            //Formatieren des PDf
            doc.Open();
            doc.AddTitle("Rechnung");
            doc.Add(new Paragraph("Rechnung\n\n\n"));
            doc.Add(new Paragraph(pdf.Zeile + pdf.Absender + "\n\n"));
            doc.Add(new Paragraph(pdf.Zeile + pdf.Empfänger + "\n\n"));
            doc.Add(new Paragraph(pdf.AustellungsDatum + "\n\n"));
            doc.Add(new Paragraph(pdf.Zeile + pdf.Zeitraum + "\n\n"));
            doc.Add(new Paragraph(pdf.Zeile + pdf.Artikel));
            doc.Add(new Paragraph(pdf.ZuZahlenderBetrag + "\n\n"));
            doc.Add(new Paragraph(pdf.FortlaufendeNummer + "\n\n"));
            doc.Add(new Paragraph(pdf.UID));
            doc.Close();
            //Download Prompt
            String FileName = "Rechnung.pdf";
            String FilePath = @"C:\Users\zalldani\Documents"; //Replace this
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
            response.TransmitFile(FilePath+@"\"+FileName);
            response.Flush();
            response.End();

            return View();
        }

        //public ActionResult GetCSV()
        //{
        //    string filename = "example";
        //    string csv = MyHelper.GetCSVString();
        //    return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", string.Format("{0}.csv", filename));
        //}
    }
}