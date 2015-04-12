namespace _1aarsproeveWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataViewContext : DbContext
    {
        public DataViewContext()
            : base("name=DataViewContext1")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<AnsatteView> AnsatteViews { get; set; }
        public virtual DbSet<HovedmenuView> HovedmenuViews { get; set; }
        public virtual DbSet<VagtplanView> VagtplanViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnsatteView>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<AnsatteView>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<AnsatteView>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<AnsatteView>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<AnsatteView>()
                .Property(e => e.Mobil)
                .IsUnicode(false);

            modelBuilder.Entity<AnsatteView>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<AnsatteView>()
                .Property(e => e.Postnummer)
                .IsUnicode(false);

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
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<VagtplanView>()
                .Property(e => e.Navn)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<_1aarsproeveWebService.Vagter> Vagters { get; set; }

        public System.Data.Entity.DbSet<_1aarsproeveWebService.Ansatte> Ansattes { get; set; }

        public System.Data.Entity.DbSet<_1aarsproeveWebService.Ugedage> Ugedages { get; set; }
    }
}
