﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAP.Logic
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ITIN20LAPEntities : DbContext
    {
        public ITIN20LAPEntities()
            : base("name=ITIN20LAPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Benutzer> AlleBenutzer { get; set; }
        public DbSet<BenutzerRollen> AlleBenutzerRollen { get; set; }
        public DbSet<Buchungen> AlleBuchungen { get; set; }
        public DbSet<Einrichtungen> AlleEinrichtungen { get; set; }
        public DbSet<Firmen> AlleFirmen { get; set; }
        public DbSet<Gebäude> AlleGebäude { get; set; }
        public DbSet<Kontakte> AlleKontakte { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Räume> AlleRäume { get; set; }
        public DbSet<RaumEinrichtungen> AlleRaumEinrichtungen { get; set; }
        public DbSet<Rechnungen> AlleRechnungen { get; set; }
        public DbSet<RechnungsDetails> AlleRechnungsDetails { get; set; }
        public DbSet<Stornierungen> AlleStornierungen { get; set; }
    }
}
