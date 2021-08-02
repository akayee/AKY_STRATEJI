using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class AKYSTRATEJIContext : DbContext
    {
        public AKYSTRATEJIContext()
        {
        }

        public AKYSTRATEJIContext(DbContextOptions<AKYSTRATEJIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BrAraclar> BrAraclars { get; set; }
        public virtual DbSet<BrBirimler> BrBirimlers { get; set; }
        public virtual DbSet<BrBirimtipleri> BrBirimtipleris { get; set; }
        public virtual DbSet<BrDonanimlar> BrDonanimlars { get; set; }
        public virtual DbSet<BrFizikselYapilar> BrFizikselYapilars { get; set; }
        public virtual DbSet<BrMevzuatlar> BrMevzuatlars { get; set; }
        public virtual DbSet<BrPersoneller> BrPersonellers { get; set; }
        public virtual DbSet<BrYazilimlar> BrYazilimlars { get; set; }
        public virtual DbSet<BrYetkiGorevTanimlari> BrYetkiGorevTanimlaris { get; set; }
        public virtual DbSet<GnOlcubirimi> GnOlcubirimis { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }
        public virtual DbSet<KullanicilarBirimler> KullanicilarBirimlers { get; set; }
        public virtual DbSet<StAmaclar> StAmaclars { get; set; }
        public virtual DbSet<StFaaliyet> StFaaliyets { get; set; }
        public virtual DbSet<StFaaliyetler> StFaaliyetlers { get; set; }
        public virtual DbSet<StHedefler> StHedeflers { get; set; }
        public virtual DbSet<StIsler> StIslers { get; set; }
        public virtual DbSet<StIsturleri> StIsturleris { get; set; }
        public virtual DbSet<StPerformanslar> StPerformanslars { get; set; }
        public virtual DbSet<StStratejiyili> StStratejiyilis { get; set; }
        public virtual DbSet<StYillikhedef> StYillikhedefs { get; set; }
        public virtual DbSet<StratejiyiliAmaclar> StratejiyiliAmaclars { get; set; }
        public virtual DbSet<StratejiyiliFaaliyetler> StratejiyiliFaaliyetlers { get; set; }
        public virtual DbSet<StratejiyiliHedefler> StratejiyiliHedeflers { get; set; }
        public virtual DbSet<StratejiyiliIsturleri> StratejiyiliIsturleris { get; set; }
        public virtual DbSet<StratejiyiliPerformanslar> StratejiyiliPerformanslars { get; set; }
        public virtual DbSet<YtYetkigruplari> YtYetkigruplaris { get; set; }
        public virtual DbSet<YtYetkiler> YtYetkilers { get; set; }
        public virtual DbSet<YtYetkilerYetkigruplari> YtYetkilerYetkigruplaris { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MAS-MLI-083\\MSSQLSERVER01;Initial Catalog=AKYSTRATEJI;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<BrAraclar>(entity =>
            {
                entity.ToTable("BR_ARACLAR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AracId).HasColumnName("AracID");

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.Cinsi).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.TahsisTuru).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.BrAraclars)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BR_ARACLAR_BR_BIRIMLER");
            });

            modelBuilder.Entity<BrBirimler>(entity =>
            {
                entity.ToTable("BR_BIRIMLER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.OlustumraTarihi).HasColumnType("date");

                entity.Property(e => e.UstBirimId).HasColumnName("UstBirimID");

                entity.HasOne(d => d.BirimTipi)
                    .WithMany(p => p.BrBirimlers)
                    .HasForeignKey(d => d.BirimTipiId)
                    .HasConstraintName("FK_BR_BIRIMLER_BR_BIRIMTIPLERI");
            });

            modelBuilder.Entity<BrBirimtipleri>(entity =>
            {
                entity.ToTable("BR_BIRIMTIPLERI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BirimTipi)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BrDonanimlar>(entity =>
            {
                entity.ToTable("BR_DONANIMLAR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.DonanimId).HasColumnName("DonanimID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.BrDonanimlars)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BR_DONANIMLAR_BR_BIRIMLER");
            });

            modelBuilder.Entity<BrFizikselYapilar>(entity =>
            {
                entity.ToTable("BR_FIZIKSEL_YAPILAR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.FizikselYapiId).HasColumnName("FizikselYapiID");

                entity.Property(e => e.Konum)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.BrFizikselYapilars)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BR_FIZIKSEL_YAPILAR_BR_BIRIMLER");
            });

            modelBuilder.Entity<BrMevzuatlar>(entity =>
            {
                entity.ToTable("BR_MEVZUATLAR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.MevzuatId).HasColumnName("MevzuatID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.Yonetmelik)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.BrMevzuatlars)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BR_MEVZUATLAR_BR_BIRIMLER");
            });

            modelBuilder.Entity<BrPersoneller>(entity =>
            {
                entity.ToTable("BR_PERSONELLER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.DogumTarihi).HasColumnType("date");

                entity.Property(e => e.IseGirisTarihi).HasColumnType("date");

                entity.Property(e => e.Kadro).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");

                entity.Property(e => e.Mezuniyet).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");

                entity.Property(e => e.Unvan).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.BrPersonellers)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BR_PERSONELLER_BR_BIRIMLER");
            });

            modelBuilder.Entity<BrYazilimlar>(entity =>
            {
                entity.ToTable("BR_YAZILIMLAR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.YazilimId).HasColumnName("YazilimID");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.BrYazilimlars)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BR_YAZILIMLAR_BR_BIRIMLER");
            });

            modelBuilder.Entity<BrYetkiGorevTanimlari>(entity =>
            {
                entity.ToTable("BR_YETKI_GOREV_TANIMLARI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.Kanun)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.YetkiGorevId).HasColumnName("YetkiGorevID");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.BrYetkiGorevTanimlaris)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BR_YETKI_GOREV_TANIMLARI_BR_BIRIMLER");
            });

            modelBuilder.Entity<GnOlcubirimi>(entity =>
            {
                entity.ToTable("GN_OLCUBIRIMI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Tanim)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Kullanicilar>(entity =>
            {
                entity.ToTable("KULLANICILAR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.KullaniciAdi)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");

                entity.Property(e => e.YetkiGruplariId).HasColumnName("YetkiGruplariID");

                entity.HasOne(d => d.YetkiGruplari)
                    .WithMany(p => p.Kullanicilars)
                    .HasForeignKey(d => d.YetkiGruplariId)
                    .HasConstraintName("FK_KULLANICILAR_YT_YETKIGRUPLARI");
            });

            modelBuilder.Entity<KullanicilarBirimler>(entity =>
            {
                entity.HasKey(e => new { e.BirimId, e.KullaniciId });

                entity.ToTable("KULLANICILAR_BIRIMLER");

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.KullanicilarBirimlers)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KULLANICILAR_BIRIMLER_BR_BIRIMLER");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullanicilarBirimlers)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KULLANICILAR_BIRIMLER_KULLANICILAR");
            });

            modelBuilder.Entity<StAmaclar>(entity =>
            {
                entity.ToTable("ST_AMACLAR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AmacId).HasColumnName("AmacID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");
            });

            modelBuilder.Entity<StFaaliyet>(entity =>
            {
                entity.ToTable("ST_FAALIYET");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FaaliyetId).HasColumnName("FaaliyetID");

                entity.Property(e => e.FaaliyetlerId).HasColumnName("FaaliyetlerID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.HasOne(d => d.Faaliyetler)
                    .WithMany(p => p.StFaaliyets)
                    .HasForeignKey(d => d.FaaliyetlerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_FAALİYET_ST_FAALİYETLER");
            });

            modelBuilder.Entity<StFaaliyetler>(entity =>
            {
                entity.ToTable("ST_FAALIYETLER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.FaaliyetlerId).HasColumnName("FaaliyetlerID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.PerformansId).HasColumnName("PerformansID");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.StFaaliyetlers)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_FAALİYETLER_BR_BIRIMLER");

                entity.HasOne(d => d.IsTuru)
                    .WithMany(p => p.StFaaliyetlers)
                    .HasForeignKey(d => d.IsTuruId)
                    .HasConstraintName("FK_ST_FAALIYETLER_ST_ISTURLERI");

                entity.HasOne(d => d.OlcuBirimiNavigation)
                    .WithMany(p => p.StFaaliyetlers)
                    .HasForeignKey(d => d.OlcuBirimi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_FAALİYETLER_GN_OLCUBIRIMI");

                entity.HasOne(d => d.Performans)
                    .WithMany(p => p.StFaaliyetlers)
                    .HasForeignKey(d => d.PerformansId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_FAALİYETLER_ST_PERFORMANSLAR");
            });

            modelBuilder.Entity<StHedefler>(entity =>
            {
                entity.ToTable("ST_HEDEFLER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AmaclarId).HasColumnName("AmaclarID");

                entity.Property(e => e.HedeflerId).HasColumnName("HedeflerID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.Tanim)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Amaclar)
                    .WithMany(p => p.StHedeflers)
                    .HasForeignKey(d => d.AmaclarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_HEDEFLER_ST_AMACLAR");
            });

            modelBuilder.Entity<StIsler>(entity =>
            {
                entity.ToTable("ST_ISLER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BaslangicTarihi).HasColumnType("date");

                entity.Property(e => e.BitisTarihi).HasColumnType("date");

                entity.Property(e => e.IsTuruId).HasColumnName("IsTuruID");

                entity.Property(e => e.IslerId).HasColumnName("IslerID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.HasOne(d => d.IsTuru)
                    .WithMany(p => p.StIslers)
                    .HasForeignKey(d => d.IsTuruId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_ISLER_ST_ISTURLERİ");
            });

            modelBuilder.Entity<StIsturleri>(entity =>
            {
                entity.ToTable("ST_ISTURLERI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Aciklama).HasMaxLength(250);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.IsTurleriId).HasColumnName("IsTurleriID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.PerformansId).HasColumnName("PerformansID");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.StIsturleris)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_ISTURLERİ_BR_BIRIMLER");

                entity.HasOne(d => d.OlcuBirimiNavigation)
                    .WithMany(p => p.StIsturleris)
                    .HasForeignKey(d => d.OlcuBirimi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_ISTURLERİ_GN_OLCUBIRIMI");

                entity.HasOne(d => d.Performans)
                    .WithMany(p => p.StIsturleris)
                    .HasForeignKey(d => d.PerformansId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_ISTURLERİ_ST_PERFORMANSLAR");
            });

            modelBuilder.Entity<StPerformanslar>(entity =>
            {
                entity.ToTable("ST_PERFORMANSLAR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HedeflerId).HasColumnName("HedeflerID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.PerformanslarId).HasColumnName("PerformanslarID");

                entity.HasOne(d => d.Hedefler)
                    .WithMany(p => p.StPerformanslars)
                    .HasForeignKey(d => d.HedeflerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_PERFORMANSLAR_ST_HEDEFLER");
            });

            modelBuilder.Entity<StStratejiyili>(entity =>
            {
                entity.ToTable("ST_STRATEJIYILI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<StYillikhedef>(entity =>
            {
                entity.HasKey(e => e.YillikHedefId)
                    .HasName("PK_ST_YILLIKHEDEF_1");

                entity.ToTable("ST_YILLIKHEDEF");

                entity.Property(e => e.YillikHedefId)
                    .ValueGeneratedNever()
                    .HasColumnName("YillikHedefID");

                entity.Property(e => e.HedefNn).HasColumnName("HedefNN");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.HasOne(d => d.Faaliyet)
                    .WithMany(p => p.StYillikhedefs)
                    .HasForeignKey(d => d.FaaliyetId)
                    .HasConstraintName("FK_ST_YILLIKHEDEF_ST_FAALIYETLER");

                entity.HasOne(d => d.IsTuru)
                    .WithMany(p => p.StYillikhedefs)
                    .HasForeignKey(d => d.IsTuruId)
                    .HasConstraintName("FK_ST_YILLIKHEDEF_ST_ISTURLERI");
            });

            modelBuilder.Entity<StratejiyiliAmaclar>(entity =>
            {
                entity.HasKey(e => new { e.AmaclarId, e.StratejiyiliId });

                entity.ToTable("STRATEJIYILI_AMACLAR");

                entity.HasOne(d => d.Amaclar)
                    .WithMany(p => p.StratejiyiliAmaclars)
                    .HasForeignKey(d => d.AmaclarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_AMACLAR_ST_AMACLAR");

                entity.HasOne(d => d.Stratejiyili)
                    .WithMany(p => p.StratejiyiliAmaclars)
                    .HasForeignKey(d => d.StratejiyiliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_AMACLAR_ST_STRATEJIYILI");
            });

            modelBuilder.Entity<StratejiyiliFaaliyetler>(entity =>
            {
                entity.HasKey(e => new { e.FaaliyetId, e.StratejiyiliId });

                entity.ToTable("STRATEJIYILI_FAALIYETLER");

                entity.HasOne(d => d.Faaliyet)
                    .WithMany(p => p.StratejiyiliFaaliyetlers)
                    .HasForeignKey(d => d.FaaliyetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_FAALIYETLER_ST_FAALİYETLER");

                entity.HasOne(d => d.Stratejiyili)
                    .WithMany(p => p.StratejiyiliFaaliyetlers)
                    .HasForeignKey(d => d.StratejiyiliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_FAALIYETLER_ST_STRATEJIYILI");
            });

            modelBuilder.Entity<StratejiyiliHedefler>(entity =>
            {
                entity.HasKey(e => new { e.HedeflerId, e.StratejiyiliId });

                entity.ToTable("STRATEJIYILI_HEDEFLER");

                entity.HasOne(d => d.Hedefler)
                    .WithMany(p => p.StratejiyiliHedeflers)
                    .HasForeignKey(d => d.HedeflerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_HEDEFLER_ST_HEDEFLER");

                entity.HasOne(d => d.Stratejiyili)
                    .WithMany(p => p.StratejiyiliHedeflers)
                    .HasForeignKey(d => d.StratejiyiliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_HEDEFLER_ST_STRATEJIYILI");
            });

            modelBuilder.Entity<StratejiyiliIsturleri>(entity =>
            {
                entity.HasKey(e => new { e.IsturuId, e.StratejiyiliId });

                entity.ToTable("STRATEJIYILI_ISTURLERI");

                entity.HasOne(d => d.Isturu)
                    .WithMany(p => p.StratejiyiliIsturleris)
                    .HasForeignKey(d => d.IsturuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_ISTURLERI_ST_ISTURLERİ");

                entity.HasOne(d => d.Stratejiyili)
                    .WithMany(p => p.StratejiyiliIsturleris)
                    .HasForeignKey(d => d.StratejiyiliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_ISTURLERI_ST_STRATEJIYILI");
            });

            modelBuilder.Entity<StratejiyiliPerformanslar>(entity =>
            {
                entity.HasKey(e => new { e.PerformanslarId, e.StratejiyiliId });

                entity.ToTable("STRATEJIYILI_PERFORMANSLAR");

                entity.HasOne(d => d.Performanslar)
                    .WithMany(p => p.StratejiyiliPerformanslars)
                    .HasForeignKey(d => d.PerformanslarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_PERFORMANSLAR_ST_PERFORMANSLAR");

                entity.HasOne(d => d.Stratejiyili)
                    .WithMany(p => p.StratejiyiliPerformanslars)
                    .HasForeignKey(d => d.StratejiyiliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRATEJIYILI_PERFORMANSLAR_ST_STRATEJIYILI");
            });

            modelBuilder.Entity<YtYetkigruplari>(entity =>
            {
                entity.ToTable("YT_YETKIGRUPLARI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YetkilerId).HasColumnName("YetkilerID");
            });

            modelBuilder.Entity<YtYetkiler>(entity =>
            {
                entity.ToTable("YT_YETKILER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YetkilerId).HasColumnName("YetkilerID");
            });

            modelBuilder.Entity<YtYetkilerYetkigruplari>(entity =>
            {
                entity.HasKey(e => new { e.YetkiGruplariId, e.YetkilerId })
                    .HasName("PK_YETKILER_YETKIBRUPLARI");

                entity.ToTable("YT_YETKILER_YETKIGRUPLARI");

                entity.Property(e => e.YetkiGruplariId).HasColumnName("YetkiGruplariID");

                entity.Property(e => e.YetkilerId).HasColumnName("YetkilerID");

                entity.HasOne(d => d.YetkiGruplari)
                    .WithMany(p => p.YtYetkilerYetkigruplaris)
                    .HasForeignKey(d => d.YetkiGruplariId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_YETKILER_YETKIBRUPLARI_YT_YETKIGRUPLARI");

                entity.HasOne(d => d.Yetkiler)
                    .WithMany(p => p.YtYetkilerYetkigruplaris)
                    .HasForeignKey(d => d.YetkilerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_YETKILER_YETKIBRUPLARI_YT_YETKILER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
