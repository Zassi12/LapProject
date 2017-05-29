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
    }
}