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
            List<Buchung> Buchungen = BuchungsVerwaltung.AlleBuchungenUser(BenutzerVerwaltung.getBenutzer( User.Identity.Name));
            List<RaumBuchungsModel> model = new List<RaumBuchungsModel>();
            
            foreach (var i in Buchungen)
            {
                RaumBuchungsModel raum = new RaumBuchungsModel();
                raum.Id = i.Raum_Id;
                raum.Vorname = i.Benutzer.Vorname;
                raum.Nachname = i.Benutzer.Nachname;
                raum.StartDatum = i.Datum;
                raum.RaumBezeichung = i.Räume.Bez;
                raum.GebäudeBezeichnung = i.Räume.Gebäude.FirmenName;
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
            model.ZuZahlenderBetrag = string.Format("{0}{1}",betrag,"€");
            model.UidLiefernder = "ATU99999999";
            model.UidEmpfänger = "ATU11111111";
            model.RechnungsNummer = 1;


            return View(model);
        }
    }
}