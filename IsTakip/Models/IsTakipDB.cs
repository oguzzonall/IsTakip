namespace IsTakip.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IsTakipDB : DbContext
    {
        public IsTakipDB()
            : base("name=IsTakipDB")
        {
        }

        public virtual DbSet<IsTakipDetay> IsTakipDetays { get; set; }
        public virtual DbSet<IsTakipDurumu> IsTakipDurumus { get; set; }
        public virtual DbSet<IsTakipGruplar> IsTakipGruplars { get; set; }
        public virtual DbSet<IsTakipIstekTipi> IsTakipIstekTipis { get; set; }
        public virtual DbSet<IsTakipIzleme> IsTakipIzlemes { get; set; }
        public virtual DbSet<IsTakipKategori> IsTakipKategoris { get; set; }
        public virtual DbSet<IsTakipMaster> IsTakipMasters { get; set; }
        public virtual DbSet<IsTakipOncelik> IsTakipOnceliks { get; set; }
        public virtual DbSet<IsTakipRoller> IsTakipRollers { get; set; }
        public virtual DbSet<IsTakipSorumlular> IsTakipSorumlulars { get; set; }
        public virtual DbSet<IsTakipYorum> IsTakipYorums { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }
        public virtual DbSet<MusteriIstekler> MusteriIsteklers { get; set; }
        public virtual DbSet<Musteriler> Musterilers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IsTakipDurumu>()
                .HasMany(e => e.IsTakipDetays)
                .WithRequired(e => e.IsTakipDurumu)
                .HasForeignKey(e => e.Durumid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IsTakipDurumu>()
                .HasMany(e => e.IsTakipSorumlulars)
                .WithRequired(e => e.IsTakipDurumu)
                .HasForeignKey(e => e.DurumuId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IsTakipGruplar>()
                .HasMany(e => e.IsTakipMasters)
                .WithRequired(e => e.IsTakipGruplar)
                .HasForeignKey(e => e.IsGrubuId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IsTakipIstekTipi>()
                .HasMany(e => e.MusteriIsteklers)
                .WithRequired(e => e.IsTakipIstekTipi)
                .HasForeignKey(e => e.IstekTipId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IsTakipKategori>()
                .HasMany(e => e.IsTakipMasters)
                .WithRequired(e => e.IsTakipKategori)
                .HasForeignKey(e => e.KategoriId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IsTakipMaster>()
                .Property(e => e.IsKodu)
                .IsUnicode(false);

            modelBuilder.Entity<IsTakipMaster>()
                .HasMany(e => e.IsTakipDetays)
                .WithRequired(e => e.IsTakipMaster)
                .HasForeignKey(e => e.Masterid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IsTakipOncelik>()
                .Property(e => e.OncelikAdi)
                .IsUnicode(false);

            modelBuilder.Entity<IsTakipOncelik>()
                .HasMany(e => e.IsTakipMasters)
                .WithRequired(e => e.IsTakipOncelik)
                .HasForeignKey(e => e.OncelikId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IsTakipRoller>()
                .HasMany(e => e.Kullanicilars)
                .WithOptional(e => e.IsTakipRoller)
                .HasForeignKey(e => e.RolId);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.KullaniciAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.IsTakipDetays)
                .WithRequired(e => e.Kullanicilar)
                .HasForeignKey(e => e.Sorumlu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.IsTakipIzlemes)
                .WithRequired(e => e.Kullanicilar)
                .HasForeignKey(e => e.Izleyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.IsTakipIzlemes1)
                .WithRequired(e => e.Kullanicilar1)
                .HasForeignKey(e => e.Izlenen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.IsTakipMasters)
                .WithRequired(e => e.Kullanicilar)
                .HasForeignKey(e => e.IsiVerenId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.IsTakipSorumlulars)
                .WithRequired(e => e.Kullanicilar)
                .HasForeignKey(e => e.Sorumlu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MusteriIstekler>()
                .HasMany(e => e.IsTakipYorums)
                .WithRequired(e => e.MusteriIstekler)
                .HasForeignKey(e => e.IstekId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteriler>()
                .HasMany(e => e.MusteriIsteklers)
                .WithRequired(e => e.Musteriler)
                .HasForeignKey(e => e.MusteriId)
                .WillCascadeOnDelete(false);
        }
    }
}
