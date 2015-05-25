namespace WS1aarsproeve
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ViewContext : DbContext
    {
        public ViewContext()
            : base("name=ViewContext7")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<AnmodningModel> AnmodningModels { get; set; }
        public virtual DbSet<BeskedModel> BeskedModels { get; set; }
        public virtual DbSet<VagtModel> VagtModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnmodningModel>()
                .Property(e => e.AnmodningBrugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<AnmodningModel>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<AnmodningModel>()
                .Property(e => e.Starttidspunkt)
                .HasPrecision(0);

            modelBuilder.Entity<AnmodningModel>()
                .Property(e => e.Sluttidspunkt)
                .HasPrecision(0);

            modelBuilder.Entity<AnmodningModel>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<AnmodningModel>()
                .Property(e => e.Ugedag)
                .IsUnicode(false);

            modelBuilder.Entity<BeskedModel>()
                .Property(e => e.Overskrift)
                .IsUnicode(false);

            modelBuilder.Entity<BeskedModel>()
                .Property(e => e.Beskrivelse)
                .IsUnicode(false);

            modelBuilder.Entity<BeskedModel>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<BeskedModel>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<VagtModel>()
                .Property(e => e.Starttidspunkt)
                .HasPrecision(0);

            modelBuilder.Entity<VagtModel>()
                .Property(e => e.Sluttidspunkt)
                .HasPrecision(0);

            modelBuilder.Entity<VagtModel>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<VagtModel>()
                .Property(e => e.Navn)
                .IsUnicode(false);
        }
    }
}
