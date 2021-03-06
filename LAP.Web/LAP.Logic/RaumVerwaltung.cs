﻿using LAP.Logic;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LAP.Logic
{
    public class RaumVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Returns a room with all necessary data according to given ID
        /// </summary>
        /// <param name="id">the ID of the room to look for</param>
        /// <returns>Returns a room with all necessary data according to given ID</returns>
        public static Raum GetRaumId(int id)
        {
            log.Info("GetRaum(id)");
            Raum room = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {

                    // filter by building and type if given
                    room = context.AlleRäume
                        .Include(x => x.Gebäude /*"Gebäude"*/)
                        .Include(x => x.AlleBuchungen/*"Buchungen"*/)
                        .Include(x => x.AlleRaumEinrichtungen/*"RaumEinrichtungen"*/)
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    log.Error("Exception in GetRaum", ex);
                    if (ex.InnerException != null)
                        log.Error("Exception in GetRaum (inner)", ex.InnerException);
                    throw;
                }
            }
            return room;
        }
        /// <summary>
        /// alle Räume aus der db
        /// </summary>
        /// <returns></returns>
        public static List<Raum> GetRäume()
        {
            log.Info("Hole alle Räume");
            List<Raum> room = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    room = context.AlleRäume
                        .Include(x => x.Gebäude /*"Gebäude"*/)
                        .Include(x => x.AlleBuchungen/*"Buchungen"*/)
                        .Include(x => x.AlleRaumEinrichtungen/*"RaumEinrichtungen"*/)
                        .Include(x => x.AlleRaumEinrichtungen.Select(y => y.Einrichtung))
                        .Where(x => x.Gebäude.active==true)
                        .ToList();
                }
                catch (Exception ex)
                {
                    log.Error("Exception in GetRaum", ex);
                    if (ex.InnerException != null)
                        log.Error("Exception in GetRaum (inner)", ex.InnerException);
                    throw;
                }
            }
            return room;

        }

            /////// <summary>
            /////// Looks for rooms according to given filter criteria. Returns list of rooms
            /////// </summary>
            /////// <param name="start">required booking start date</param>
            /////// <param name="end">required booking end date</param>
            /////// <param name="idFacilities"></param>
            /////// <param name="idBuilding"></param>
            /////// <param name="idType"></param>
            /////// <returns>List of rooms according to given filter criteria</returns>
            ////public static List<room> Search(string start, string end, int[] idFacilities, int? idBuilding, int? idType)
            ////{
            ////    log.Info("SaveCompanyData(companyId, companyName, street, number, zip, city)");
            ////    List<room> availableRooms = null;

            ////    DateTime startValue, endValue;

            ////    if (string.IsNullOrEmpty(start) || !DateTime.TryParse(start, out startValue))
            ////    {
            ////        throw new ArgumentException("Invalid Value", nameof(start));
            ////    }
            ////    else if (string.IsNullOrEmpty(end) || !DateTime.TryParse(end, out endValue))
            ////    {
            ////        throw new ArgumentException("Invalid Value", nameof(end));
            ////    }
            ////    else if (idBuilding.HasValue && idBuilding <= 0)
            ////    {
            ////        throw new ArgumentException("Invalid Value", nameof(idBuilding));
            ////    }
            ////    else if (idType.HasValue && idType <= 0)
            ////    {
            ////        throw new ArgumentException("Invalid Value", nameof(idType));
            ////    }
            ////    else
            ////    {
            ////        using (var context = new ITIN20LAPEntities())
            ////        {
            ////            try
            ////            {
            ////                // get all booked rooms for given range
            ////                List<room> bookedRooms =
            ////                    context.AllBookingDetails
            ////                        .Where(x => x.Date >= startValue && x.Date <= endValue)
            ////                        .Select(x => x.Booking.Room)
            ////                    .ToList();

            ////                // filter by building and type if given
            ////                availableRooms = context.AllRooms
            ////                    .Include("Building")
            ////                    .Include("Type")
            ////                    .Include("AllRoomFacilities")
            ////                    .Include("AllRoomFacilities.Facility")
            ////                    .Where(x =>
            ////                        (!idBuilding.HasValue || x.ID_Building == idBuilding) &&
            ////                        (!idType.HasValue || x.ID_Type == idType)
            ////                    ).ToList();

            ////                // exclude booked Rooms
            ////                availableRooms = availableRooms.Except(bookedRooms).ToList();

            ////                // get all rooms for given facilities criteria
            ////                if (idFacilities != null && idFacilities.Length > 0)
            ////                {
            ////                    availableRooms =
            ////                        availableRooms
            ////                        // prüfe jeden verfügbaren raum
            ////                        .Where(x =>
            ////                    a        // nimm die raum ausstattungs IDs 
            ////                            x.AllRoomFacilities.Select(y => y.ID_Facility)
            ////                            // und bilde die schnittmenge zu den gesuchten raum austattungen
            ////                            .Intersect(idFacilities)
            ////                            // wenn die anzahl der schmittmenge gleich der anzahl der gesuchten elemente ist
            ////                            // dann soll dieser raus in die ergebnismenge
            ////                            .Count() == idFacilities.Count())
            ////                        .ToList();


            ////                    /// Variante "auch möglich"
            ////                    /// gehe jeden Raum durch mit einer Schleife
            ////                    ///     gehe alle gewünschten Ausstattungen durch
            ////                    ///         wenn eine gewünschte Ausstattung NICHT bei den Raumausstattungen vorkommt
            ////                    ///             schmeiße diesen Raum raus.
            ////                }
            ////            }
            ////            catch (Exception ex)
            ////            {
            ////                log.Error("Exception in Search", ex);
            ////                if (ex.InnerException != null)
            ////                    log.Error("Exception in Search (inner)", ex.InnerException);
            ////                throw;
            ////            }
            ////        }
            ////    }
            ////    return availableRooms;
            ////}
        }
}
