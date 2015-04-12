namespace _1aarsproeveWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataTableContext : DbContext
    {
        public DataTableContext()
            : base("name=DataTableContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Ansatte> Ansattes { get; set; }
        public virtual DbSet<Beskeder> Beskeders { get; set; }
        public virtual DbSet<Stillinger> Stillingers { get; set; }
        public virtual DbSet<Ugedage> Ugedages { get; set; }
        public virtual DbSet<Vagter> Vagters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ansatte>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<Ansatte>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Ansatte>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Ansatte>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Ansatte>()
                .Property(e => e.Mobil)
                .IsUnicode(false);

            modelBuilder.Entity<Ansatte>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Ansatte>()
                .Property(e => e.Postnummer)
                .IsUnicode(false);

            modelBuilder.Entity<Ansatte>()
                .HasMany(e => e.Beskeders)
                .WithRequired(e => e.Ansatte)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ansatte>()
                .HasMany(e => e.Vagters)
                .WithRequired(e => e.Ansatte)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beskeder>()
                .Property(e => e.Overskrift)
                .IsUnicode(false);

            modelBuilder.Entity<Beskeder>()
                .Property(e => e.Beskrivelse)
                .IsUnicode(false);

            modelBuilder.Entity<Beskeder>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<Stillinger>()
                .Property(e => e.Stilling)
                .IsUnicode(false);

            modelBuilder.Entity<Stillinger>()
                .HasMany(e => e.Ansattes)
                .WithRequired(e => e.Stillinger)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ugedage>()
                .Property(e => e.Ugedag)
                .IsUnicode(false);

            modelBuilder.Entity<Ugedage>()
                .HasMany(e => e.Vagters)
                .WithRequired(e => e.Ugedage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vagter>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);
        }
    }
}
