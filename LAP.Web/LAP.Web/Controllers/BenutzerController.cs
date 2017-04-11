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

namespace LAP.Web.Controllers
{
    public class BenutzerController : Controller
    {
        public bool istMitarbeiter;

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
                if (Tools.IstMitarbeiter(lm.Email))
                {
                    istMitarbeiter = true;
                    return RedirectToAction("Index", "Mitarbeiter");
                }
                else
                {
                    istMitarbeiter = false;
                    return RedirectToAction("ProfilAnsicht", "Benutzer");
                }
            }

            return RedirectToAction("Login", "Benutzer");
        }


        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ProfilAnsicht(ProfileDataModel pfdm)
        {
            ProfilVerwaltung pv = new ProfilVerwaltung();

            var puser = pv.GetProfileData(User.Identity.Name);
            pfdm.Benutzername = puser.email;
            pfdm.Nachname = puser.lastname;
            pfdm.Vorname = puser.firstname;
            pfdm.Passwort = Encoding.Default.GetString(puser.password);
            return View(pfdm);
        }
    }
}