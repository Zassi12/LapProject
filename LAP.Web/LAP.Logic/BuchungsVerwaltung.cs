using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace LAP.Logic
{
    public class BuchungsVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static List<Stornierung> AlleStornierungen()
        {
            List<Stornierung> stornos = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    //stornos = context.AlleStornierungen.Include("Benutzer").Include("Buchungen").ToList();
                    stornos = context.AlleStornierungen
                        .Include(x => x.Benutzer)
                        .Include(x => x.Benutzer.Firma)
                        .Include(x => x.Buchung)
                        .Include(x => x.Buchung.Räume)
                        .Include(x => x.Buchung.Räume.Gebäude)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleStornierungen", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleStornierungen (inner)", ex.InnerException);
                throw;
            }

            return stornos;
        }

        /// <summary>
        /// Alle Stornierungen nach Datum
        /// </summary>
        /// <param name="date">datetime datum</param>
        /// <returns></returns>
        public static List<Stornierung> AlleStornierungenDatum(DateTime datum)
        {


            List<Stornierung> Stornobydate = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    Stornobydate = context.AlleStornierungen
                        .Include(x => x.Benutzer)
                        .Include(x => x.Benutzer.Firma)
                        .Include(x => x.Buchung)
                        .Include(x => x.Buchung.Räume)
                        .Include(x => x.Buchung.Räume.Gebäude)
                        .Where(x => (x.Buchung.Datum == datum))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleStornierungenDatum", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleStornierungenDatum (inner)", ex.InnerException);
                throw;
            }

            return Stornobydate;
        }

        public static List<Buchung> AlleBuchungen()
        {
            List<Buchung> bookings = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {

                    bookings = context.AlleBuchungen
                        .Include(x => x.Benutzer)
                        .Include(x => x.Benutzer.Firma)
                        .Include(x => x.AlleRechnungsDetails)
                        .Include(x => x.AlleStornierungen)
                        .Include(x => x.Räume)
                        .Include(x => x.Räume.Gebäude)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleStornierungenDatum", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleStornierungenDatum (inner)", ex.InnerException);
                throw;
            }

            return bookings;
        }



        /// <summary>
        /// Alle Buchungen in der Db
        /// </summary>
        /// <returns></returns>
        public static List<Buchung> AlleBuchungenDatum(DateTime datum)
        {
            List<Buchung> bookings = new List<Buchung>();

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    context.AlleBuchungen
                        .Include(x => x.Benutzer)
                        .Include(x => x.Benutzer.Firma)
                        .Include(x => x.AlleRechnungsDetails)
                        .Include(x => x.AlleStornierungen)
                        .Include(x => x.Räume)
                        .Include(x => x.Räume.Gebäude)
                        .Where(x => x.Datum == datum)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleBuchungen", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleBuchungen (inner)", ex.InnerException);
                throw;
            }
            return bookings;

        }

        /// <summary>
        /// Alle Buchungen in der Db
        /// </summary>
        /// <returns></returns>
        public static List<Buchung> AlleBuchungenId(int id)
        {
            List<Buchung> bookings = new List<Buchung>();

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    context.AlleBuchungen
                        .Include(x => x.Benutzer)
                        .Include(x => x.Benutzer.Firma)
                        .Include(x => x.AlleRechnungsDetails)
                        .Include(x => x.AlleStornierungen)
                        .Include(x => x.Räume)
                        .Include(x => x.Räume.Gebäude)
                        .Where(x => x.Raum_Id == id)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleBuchungenId", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleBuchungenId (inner)", ex.InnerException);
                throw;
            }
            return bookings;

        }

        /// <summary>
        /// Alle Buchungen in der Db
        /// </summary>
        /// <returns></returns>
        public static List<Buchung> AlleBuchungenUser(Benutzer user)
        {
            List<Buchung> bookings = null;
           
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    bookings = context.AlleBuchungen
                        .Include(x => x.Benutzer)
                        .Include(x => x.Benutzer.Firma)
                        .Include(x => x.AlleRechnungsDetails)
                        .Include(x => x.AlleStornierungen)
                        .Include(x => x.Räume)
                        .Include(x => x.Räume.Gebäude)
                        .Where(x => x.Benutzer.Email == user.Email)
                        //.Where(x => x.Benutzer.Id == user.Id)
                        
                        .ToList();
                }

            }
            catch (Exception ex)
            {
                log.Error("Exception in AlleBuchungenId", ex);
                if (ex.InnerException != null)
                    log.Error("Exception in AlleBuchungenId (inner)", ex.InnerException);
                throw;
            }
            return bookings;

        }

    }

}
