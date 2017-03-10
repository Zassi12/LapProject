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
            if ( logval == LogonResult.LogonDataValid)
            {
                if (lm.AngemeldetBleiben)
                {
                    FormsAuthentication.SetAuthCookie(lm.Email, true);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(lm.Email, false);
                }
                if (Tools.IstMitarbeiter(lm.Email))
                {
                    return RedirectToAction("Verwaltung", "Benutzer");
                }
                //wenn der User nicht von Benutzer/Verwaltung kommt leite ihn dahin weiter woher er kam
                if (!Request.UrlReferrer.AbsoluteUri.Contains("Benutzer/Verwaltung"))
                {
                    return Redirect(Request.UrlReferrer.AbsoluteUri);
                }
        }

            return RedirectToAction("Login", "Benutzer");
        }


        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Verwaltung()
        {
            ProfileDataModel pfdm = new ProfileDataModel();

            return View();
        }

        [HttpPost]
        public ActionResult Verwaltung(ProfileDataModel pfdm)
        {
            return View();
        }

    }
}