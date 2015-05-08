namespace WS1aarsproeve
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ViewContext : DbContext
    {
        public ViewContext()
            : base("name=ViewContext2")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<HovedmenuView> HovedmenuViews { get; set; }
        public virtual DbSet<VagtplanView> VagtplanViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HovedmenuView>()
                .Property(e => e.Overskrift)
                .IsUnicode(false);

            modelBuilder.Entity<HovedmenuView>()
                .Property(e => e.Beskrivelse)
                .IsUnicode(false);

            modelBuilder.Entity<HovedmenuView>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<HovedmenuView>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<VagtplanView>()
                .Property(e => e.Starttidspunkt)
                .HasPrecision(0);

            modelBuilder.Entity<VagtplanView>()
                .Property(e => e.Sluttidspunkt)
                .HasPrecision(0);

            modelBuilder.Entity<VagtplanView>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<VagtplanView>()
                .Property(e => e.Navn)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<WS1aarsproeve.Vagter> Vagters { get; set; }

        public System.Data.Entity.DbSet<WS1aarsproeve.Ansatte> Ansattes { get; set; }

        public System.Data.Entity.DbSet<WS1aarsproeve.Ugedage> Ugedages { get; set; }
    }
}
