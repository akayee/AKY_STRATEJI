using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AKYSTRATEJI.Models
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
        public virtual DbSet<BrDonanimlar> BrDonanimlars { get; set; }
        public virtual DbSet<BrFizikselYapilar> BrFizikselYapilars { get; set; }
        public virtual DbSet<BrMevzuatlar> BrMevzuatlars { get; set; }
        public virtual DbSet<BrPersoneller> BrPersonellers { get; set; }
        public virtual DbSet<BrYazilimlar> BrYazilimlars { get; set; }
        public virtual DbSet<BrYetkiGorevTanimlari> BrYetkiGorevTanimlaris { get; set; }
        public virtual DbSet<FlFaaliyet> FlFaaliyets { get; set; }
        public virtual DbSet<FlFaaliyetturleri> FlFaaliyetturleris { get; set; }
        public virtual DbSet<GnOlcubirimi> GnOlcubirimis { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }
        public virtual DbSet<KullanicilarBirimler> KullanicilarBirimlers { get; set; }
        public virtual DbSet<StAmaclar> StAmaclars { get; set; }
        public virtual DbSet<StFaalİyet> StFaalİyets { get; set; }
        public virtual DbSet<StFaalİyetler> StFaalİyetlers { get; set; }
        public virtual DbSet<StHedefler> StHedeflers { get; set; }
        public virtual DbSet<StIsler> StIslers { get; set; }
        public virtual DbSet<StIsturlerİ> StIsturlerİs { get; set; }
        public virtual DbSet<StPerformanslar> StPerformanslars { get; set; }
        public virtual DbSet<StYillikhedef> StYillikhedefs { get; set; }
        public virtual DbSet<YtYetkigruplari> YtYetkigruplaris { get; set; }
        public virtual DbSet<YtYetkiler> YtYetkilers { get; set; }
        public virtual DbSet<YtYetkilerYetkigruplari> YtYetkilerYetkigruplaris { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AKYSTRATEJI;Integrated Security=True");
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

            modelBuilder.Entity<FlFaaliyet>(entity =>
            {
                entity.ToTable("FL_FAALIYET");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BaslangicTarihi).HasColumnType("date");

                entity.Property(e => e.BitisTarihi).HasColumnType("date");

                entity.Property(e => e.FaaliyetId).HasColumnName("FaaliyetID");

                entity.Property(e => e.FaaliyetTurleriId).HasColumnName("FaaliyetTurleriID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.HasOne(d => d.FaaliyetTurleri)
                    .WithMany(p => p.FlFaaliyets)
                    .HasForeignKey(d => d.FaaliyetTurleriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FL_FAALIYET_FL_FAALIYETTURLERI");
            });

            modelBuilder.Entity<FlFaaliyetturleri>(entity =>
            {
                entity.ToTable("FL_FAALIYETTURLERI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Aciklama)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.FaaliyetTuruId).HasColumnName("FaaliyetTuruID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.FlFaaliyetturleris)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FL_FAALIYETTURLERI_BR_BIRIMLER");

                entity.HasOne(d => d.OlcuBirimiNavigation)
                    .WithMany(p => p.FlFaaliyetturleris)
                    .HasForeignKey(d => d.OlcuBirimi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FL_FAALIYETTURLERI_GN_OLCUBIRIMI");
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
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AmacId).HasColumnName("AmacID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");
            });

            modelBuilder.Entity<StFaalİyet>(entity =>
            {
                entity.ToTable("ST_FAALİYET");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FaaliyetId).HasColumnName("FaaliyetID");

                entity.Property(e => e.FaaliyetlerId).HasColumnName("FaaliyetlerID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.HasOne(d => d.Faaliyetler)
                    .WithMany(p => p.StFaalİyets)
                    .HasForeignKey(d => d.FaaliyetlerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_FAALİYET_ST_FAALİYETLER");
            });

            modelBuilder.Entity<StFaalİyetler>(entity =>
            {
                entity.ToTable("ST_FAALİYETLER");

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

                entity.Property(e => e.YillikHedefId).HasColumnName("YillikHedefID");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.StFaalİyetlers)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_FAALİYETLER_BR_BIRIMLER");

                entity.HasOne(d => d.OlcuBirimiNavigation)
                    .WithMany(p => p.StFaalİyetlers)
                    .HasForeignKey(d => d.OlcuBirimi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_FAALİYETLER_GN_OLCUBIRIMI");

                entity.HasOne(d => d.Performans)
                    .WithMany(p => p.StFaalİyetlers)
                    .HasForeignKey(d => d.PerformansId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_FAALİYETLER_ST_PERFORMANSLAR");

                entity.HasOne(d => d.YillikHedef)
                    .WithMany(p => p.StFaalİyetlers)
                    .HasForeignKey(d => d.YillikHedefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_FAALİYETLER_ST_YILLIKHEDEF");
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
                    .HasMaxLength(50);

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

            modelBuilder.Entity<StIsturlerİ>(entity =>
            {
                entity.ToTable("ST_ISTURLERİ");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimId).HasColumnName("BirimID");

                entity.Property(e => e.IsTurleriId).HasColumnName("IsTurleriID");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.PerformansId).HasColumnName("PerformansID");

                entity.Property(e => e.YillikHedefId).HasColumnName("YillikHedefID");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.StIsturlerİs)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_ISTURLERİ_BR_BIRIMLER");

                entity.HasOne(d => d.OlcuBirimiNavigation)
                    .WithMany(p => p.StIsturlerİs)
                    .HasForeignKey(d => d.OlcuBirimi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_ISTURLERİ_GN_OLCUBIRIMI");

                entity.HasOne(d => d.Performans)
                    .WithMany(p => p.StIsturlerİs)
                    .HasForeignKey(d => d.PerformansId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_ISTURLERİ_ST_PERFORMANSLAR");

                entity.HasOne(d => d.YillikHedef)
                    .WithMany(p => p.StIsturlerİs)
                    .HasForeignKey(d => d.YillikHedefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ST_ISTURLERİ_ST_YILLIKHEDEF");
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

            modelBuilder.Entity<StYillikhedef>(entity =>
            {
                entity.ToTable("ST_YILLIKHEDEF");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.HedefNn).HasColumnName("HedefNN");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("date");

                entity.Property(e => e.YillikHedefId).HasColumnName("YillikHedefID");
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
