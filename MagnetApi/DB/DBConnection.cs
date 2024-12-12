using MagnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagnetApi.DB
    {
    public class DBConnection:DbContext
        {
        public DBConnection(DbContextOptions<DBConnection> options) : base(options)
            {
            }
        public virtual DbSet<BazaFv> BazaFvs { get; set; }

        public virtual DbSet<CorrectionInvoice> CorrectionInvoices { get; set; }

        public virtual DbSet<Dostawca> Dostawcas { get; set; }

        public virtual DbSet<FakturaNew> FakturaNews { get; set; }

        public virtual DbSet<Fv> Fvs { get; set; }

        public virtual DbSet<Klucze> Kluczes { get; set; }

        public virtual DbSet<Kontrahenci> Kontrahencis { get; set; }

        public virtual DbSet<KsefAddresApi> KsefAddresApis { get; set; }

        public virtual DbSet<NumerFv> NumerFvs { get; set; }

        public virtual DbSet<Odbiorca> Odbiorcas { get; set; }

        public virtual DbSet<OwnPurchase> OwnPurchases { get; set; }

        public virtual DbSet<RaportDobowy> RaportDobowies { get; set; }

        public virtual DbSet<RaportMiesiac> RaportMiesiacs { get; set; }

        public virtual DbSet<RaportRoczny> RaportRocznies { get; set; }

        public virtual DbSet<SerwisItem> SerwisItems { get; set; }

        public virtual DbSet<Sprzedaz> Sprzedazs { get; set; }

        public virtual DbSet<Stan> Stans { get; set; }

        public virtual DbSet<StawkiVat> StawkiVats { get; set; }

        public virtual DbSet<Tusluga> Tuslugas { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Wystawca> Wystawcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<BazaFv>(entity =>
            {
                entity.HasKey(e => e.Numer).HasName("PRIMARY");

                entity
                    .ToTable("baza_fv")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Numer)
                    .HasMaxLength(40)
                    .HasColumnName("numer");
                entity.Property(e => e.CzyZgloszonoDoKsef).HasColumnName("czy_zgloszono_do_ksef");
                entity.Property(e => e.Data)
                    .HasMaxLength(20)
                    .HasColumnName("data");
                entity.Property(e => e.DataWystawienia)
                    .HasMaxLength(25)
                    .HasColumnName("data_wystawienia");
                entity.Property(e => e.DataZaplaty)
                    .HasMaxLength(25)
                    .HasColumnName("data_zaplaty");
                entity.Property(e => e.DataZgloszneiaDoKsef)
                    .HasMaxLength(25)
                    .HasColumnName("data_zgloszneia_do_ksef");
                entity.Property(e => e.DniTerminu)
                    .HasMaxLength(6)
                    .HasColumnName("dni_terminu");
                entity.Property(e => e.Godzina)
                    .HasMaxLength(15)
                    .HasColumnName("godzina");
                entity.Property(e => e.Gtu1)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_1");
                entity.Property(e => e.Gtu10)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_10");
                entity.Property(e => e.Gtu11)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_11");
                entity.Property(e => e.Gtu12)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_12");
                entity.Property(e => e.Gtu13)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_13");
                entity.Property(e => e.Gtu2)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_2");
                entity.Property(e => e.Gtu3)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_3");
                entity.Property(e => e.Gtu4)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_4");
                entity.Property(e => e.Gtu5)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_5");
                entity.Property(e => e.Gtu6)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_6");
                entity.Property(e => e.Gtu7)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_7");
                entity.Property(e => e.Gtu8)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_8");
                entity.Property(e => e.Gtu9)
                    .HasMaxLength(4)
                    .HasColumnName("GTU_9");
                entity.Property(e => e.IdentificationNumberOfInvoiceInKseF)
                    .HasMaxLength(64)
                    .HasColumnName("Identification_number_of_invoice_in_KseF");
                entity.Property(e => e.Klient)
                    .HasMaxLength(255)
                    .HasColumnName("klient")
                    .UseCollation("cp1250_polish_ci")
                    .HasCharSet("cp1250");
                entity.Property(e => e.Kod1)
                    .HasMaxLength(15)
                    .HasColumnName("KOD1");
                entity.Property(e => e.Kod2)
                    .HasMaxLength(15)
                    .HasColumnName("KOD2");
                entity.Property(e => e.KodMiasto)
                    .HasMaxLength(150)
                    .HasColumnName("kod_miasto")
                    .UseCollation("cp1250_polish_ci")
                    .HasCharSet("cp1250");
                entity.Property(e => e.KsefReferenceNumber)
                    .HasMaxLength(64)
                    .HasColumnName("ksefReferenceNumber");
                entity.Property(e => e.KwotaBrut)
                    .HasMaxLength(12)
                    .HasColumnName("kwota_brut");
                entity.Property(e => e.Nip)
                    .HasMaxLength(20)
                    .HasColumnName("nip");
                entity.Property(e => e.Odbiorca)
                    .HasMaxLength(300)
                    .HasColumnName("odbiorca");
                entity.Property(e => e.PozDoZap)
                    .HasMaxLength(6)
                    .HasColumnName("poz_do_zap");
                entity.Property(e => e.Termin)
                    .HasMaxLength(15)
                    .HasColumnName("termin");
                entity.Property(e => e.Ulica)
                    .HasMaxLength(150)
                    .HasColumnName("ulica")
                    .UseCollation("cp1250_polish_ci")
                    .HasCharSet("cp1250");
                entity.Property(e => e.XmlContent)
                    .HasColumnType("text")
                    .HasColumnName("xml_Content")
                    .UseCollation("utf8mb4_unicode_ci")
                    .HasCharSet("utf8mb4");
                entity.Property(e => e.XmlFile)
                    .HasMaxLength(255)
                    .HasColumnName("xml_file");
                entity.Property(e => e.Zaplacono)
                    .HasMaxLength(6)
                    .HasColumnName("zaplacono");
            });

            modelBuilder.Entity<CorrectionInvoice>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("correction_invoices");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.CorrectionReason)
                    .HasColumnType("text")
                    .HasColumnName("correction_reason");
                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(150)
                    .HasColumnName("invoice_number");
                entity.Property(e => e.IssueDate).HasColumnName("issue_date");
                entity.Property(e => e.IssueDateCorrection).HasColumnName("issue_date_correction");
                entity.Property(e => e.Nip)
                    .HasMaxLength(20)
                    .HasColumnName("nip");
                entity.Property(e => e.OriginalInvoiceId)
                    .HasMaxLength(150)
                    .HasColumnName("original_invoice_id");
                entity.Property(e => e.TotalGross)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_gross");
                entity.Property(e => e.TotalNet)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_net");
                entity.Property(e => e.TotalVat)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_vat");
            });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("Dostawca")
                    .HasCharSet("latin2")
                    .UseCollation("latin2_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.DataZakupu).HasMaxLength(15);
                entity.Property(e => e.DowodZakupu).HasMaxLength(25);
                entity.Property(e => e.Kod1)
                    .HasMaxLength(5)
                    .HasColumnName("KOD1");
                entity.Property(e => e.Kod2)
                    .HasMaxLength(5)
                    .HasColumnName("KOD2");
                entity.Property(e => e.Kod3)
                    .HasMaxLength(5)
                    .HasColumnName("KOD3");
                entity.Property(e => e.Kod4)
                    .HasMaxLength(5)
                    .HasColumnName("KOD4");
                entity.Property(e => e.Kod5)
                    .HasMaxLength(5)
                    .HasColumnName("KOD5");
                entity.Property(e => e.NazwaDostawcy).HasMaxLength(250);
                entity.Property(e => e.Netto23).HasColumnName("netto_23");
                entity.Property(e => e.Netto5)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("netto_5");
                entity.Property(e => e.Netto8).HasColumnName("netto_8");
                entity.Property(e => e.NrDostawcy).HasMaxLength(15);
                entity.Property(e => e.NumerZamowienia)
                    .HasMaxLength(50)
                    .HasColumnName("numer_zamowienia");
                entity.Property(e => e.Podatek23)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("podatek_23");
                entity.Property(e => e.Podatek5)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("podatek_5");
                entity.Property(e => e.Podatek8)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("podatek_8");
                entity.Property(e => e.Vat23)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("vat_23");
                entity.Property(e => e.Vat5)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("vat_5");
                entity.Property(e => e.Vat8)
                    .HasDefaultValueSql("'0'")
                    .HasColumnName("vat_8");
            });

            modelBuilder.Entity<FakturaNew>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("faktura_new")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(25)")
                    .HasColumnName("id");
                entity.Property(e => e.CeanaBrutto).HasColumnName("ceana_brutto");
                entity.Property(e => e.Data)
                    .HasMaxLength(10)
                    .HasColumnName("data");
                entity.Property(e => e.Gtu)
                    .HasMaxLength(10)
                    .HasColumnName("GTU");
                entity.Property(e => e.Ilosc).HasColumnName("ilosc");
                entity.Property(e => e.Jm)
                    .HasMaxLength(10)
                    .HasColumnName("jm");
                entity.Property(e => e.Kod)
                    .HasMaxLength(10)
                    .HasColumnName("KOD");
                entity.Property(e => e.Kod1)
                    .HasMaxLength(10)
                    .HasColumnName("kod1");
                entity.Property(e => e.Lp)
                    .HasColumnType("int(40)")
                    .HasColumnName("lp");
                entity.Property(e => e.Nazwa)
                    .HasMaxLength(255)
                    .HasColumnName("nazwa");
                entity.Property(e => e.NumerFv)
                    .HasMaxLength(15)
                    .HasColumnName("numer_fv");
                entity.Property(e => e.StawkaVat)
                    .HasMaxLength(5)
                    .HasColumnName("stawka_vat");
                entity.Property(e => e.WartoscBrutto).HasColumnName("wartosc_brutto");
                entity.Property(e => e.WartoscNetto).HasColumnName("wartosc_netto");
                entity.Property(e => e.WartoscVat).HasColumnName("wartosc_vat");
            });

            modelBuilder.Entity<Fv>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("fv")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Domyslna)
                    .HasColumnType("int(3)")
                    .HasColumnName("domyslna");
                entity.Property(e => e.NumerFv)
                    .HasColumnType("int(255)")
                    .HasColumnName("numer_fv");
                entity.Property(e => e.Sva)
                    .HasColumnType("int(11)")
                    .HasColumnName("SVA");
                entity.Property(e => e.Svb)
                    .HasColumnType("int(11)")
                    .HasColumnName("SVB");
                entity.Property(e => e.Svc)
                    .HasColumnType("int(11)")
                    .HasColumnName("SVC");
                entity.Property(e => e.Svd)
                    .HasColumnType("int(11)")
                    .HasColumnName("SVD");
                entity.Property(e => e.Sve)
                    .HasColumnType("int(11)")
                    .HasColumnName("SVE");
                entity.Property(e => e.Svf)
                    .HasColumnType("int(11)")
                    .HasColumnName("SVF");
                entity.Property(e => e.Svg)
                    .HasMaxLength(5)
                    .HasColumnName("SVG");
            });

            modelBuilder.Entity<Klucze>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("klucze");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Data)
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("datetime")
                    .HasColumnName("data");
                entity.Property(e => e.Klucz)
                    .HasMaxLength(255)
                    .HasColumnName("klucz");
                entity.Property(e => e.NazwaKlucza)
                    .HasMaxLength(255)
                    .HasColumnName("nazwa_klucza");
                entity.Property(e => e.Opis)
                    .HasColumnType("text")
                    .HasColumnName("opis");
            });

            modelBuilder.Entity<Kontrahenci>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("kontrahenci")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(25)")
                    .HasColumnName("id");
                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .HasColumnName("email");
                entity.Property(e => e.Gmina).HasMaxLength(60);
                entity.Property(e => e.KodPocztowy).HasMaxLength(7);
                entity.Property(e => e.Miasto)
                    .HasMaxLength(100)
                    .HasColumnName("miasto")
                    .UseCollation("cp1250_polish_ci")
                    .HasCharSet("cp1250");
                entity.Property(e => e.Nazwa)
                    .HasMaxLength(100)
                    .HasColumnName("nazwa")
                    .UseCollation("cp1250_polish_ci")
                    .HasCharSet("cp1250");
                entity.Property(e => e.Nip)
                    .HasMaxLength(20)
                    .HasColumnName("nip");
                entity.Property(e => e.NrDomu).HasMaxLength(7);
                entity.Property(e => e.Obrot).HasColumnName("obrot");
                entity.Property(e => e.Odbiorca)
                    .HasMaxLength(450)
                    .HasColumnName("odbiorca");
                entity.Property(e => e.OstatniaFv)
                    .HasMaxLength(60)
                    .HasColumnName("ostatnia_fv");
                entity.Property(e => e.Powiat).HasMaxLength(60);
                entity.Property(e => e.Reprezentant)
                    .HasMaxLength(60)
                    .HasColumnName("reprezentant")
                    .UseCollation("cp1250_polish_ci")
                    .HasCharSet("cp1250");
                entity.Property(e => e.Skrot)
                    .HasMaxLength(15)
                    .HasColumnName("skrot");
                entity.Property(e => e.Telefon)
                    .HasMaxLength(25)
                    .HasColumnName("telefon");
                entity.Property(e => e.Ulica)
                    .HasMaxLength(100)
                    .HasColumnName("ulica")
                    .UseCollation("cp1250_polish_ci")
                    .HasCharSet("cp1250");
                entity.Property(e => e.Wojewodztwo).HasMaxLength(60);
            });

            modelBuilder.Entity<KsefAddresApi>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("ksef_addres_api");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Address)
                    .HasMaxLength(512)
                    .HasColumnName("address");
                entity.Property(e => e.Data)
                    .HasMaxLength(15)
                    .HasColumnName("data");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Nip)
                    .HasMaxLength(15)
                    .HasColumnName("nip");
                entity.Property(e => e.PublicKeyPem)
                    .HasColumnType("text")
                    .HasColumnName("public_key_pem");
                entity.Property(e => e.Selected).HasColumnName("selected");
                entity.Property(e => e.Token)
                    .HasMaxLength(500)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<NumerFv>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("numer_fv")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Nip)
                    .HasMaxLength(25)
                    .HasColumnName("nip");
                entity.Property(e => e.NumerFv1)
                    .HasMaxLength(255)
                    .HasColumnName("numer_fv");
                entity.Property(e => e.NumerFvk)
                    .HasMaxLength(255)
                    .HasColumnName("numer_fvk");
                entity.Property(e => e.NumerKp)
                    .HasMaxLength(255)
                    .HasColumnName("numer_kp");
                entity.Property(e => e.ProcentUstawowy)
                    .HasMaxLength(5)
                    .HasColumnName("procent_ustawowy");
            });

            modelBuilder.Entity<Odbiorca>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("odbiorca")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Adres)
                    .HasMaxLength(300)
                    .HasColumnName("adres");
                entity.Property(e => e.Nazwa).HasMaxLength(150);
                entity.Property(e => e.Nip)
                    .HasMaxLength(15)
                    .HasColumnName("nip");
            });

            modelBuilder.Entity<OwnPurchase>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("Own_purchases")
                    .HasCharSet("latin2")
                    .UseCollation("latin2_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Date).HasMaxLength(15);
                entity.Property(e => e.InvoiceNr)
                    .HasMaxLength(50)
                    .HasColumnName("Invoice_nr");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Price).HasMaxLength(10);
            });

            modelBuilder.Entity<RaportDobowy>(entity =>
            {
                entity.HasKey(e => e.Data).HasName("PRIMARY");

                entity
                    .ToTable("raport_dobowy")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Data)
                    .HasMaxLength(25)
                    .HasColumnName("data");
                entity.Property(e => e.Godzina)
                    .HasMaxLength(15)
                    .HasColumnName("GODZINA");
                entity.Property(e => e.Gotowka)
                    .HasMaxLength(10)
                    .HasColumnName("GOTOWKA");
                entity.Property(e => e.Id)
                    .HasColumnType("int(9)")
                    .HasColumnName("id");
                entity.Property(e => e.Raportujacy)
                    .HasMaxLength(50)
                    .HasColumnName("raportujacy");
                entity.Property(e => e.RoznicaVat).HasColumnName("roznica_vat");
                entity.Property(e => e.Sva).HasColumnName("SVA");
                entity.Property(e => e.Svb).HasColumnName("SVB");
                entity.Property(e => e.Svc).HasColumnName("SVC");
                entity.Property(e => e.Svd).HasColumnName("SVD");
                entity.Property(e => e.Sve).HasColumnName("SVE");
                entity.Property(e => e.Svf).HasColumnName("SVF");
                entity.Property(e => e.Svg).HasColumnName("SVG");
                entity.Property(e => e.UtargBrutto).HasColumnName("utarg_brutto");
                entity.Property(e => e.Zysk).HasColumnName("zysk");
            });

            modelBuilder.Entity<RaportMiesiac>(entity =>
            {
                entity.HasKey(e => e.Data).HasName("PRIMARY");

                entity
                    .ToTable("raport_miesiac")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Data)
                    .HasMaxLength(15)
                    .HasColumnName("data");
                entity.Property(e => e.Id)
                    .HasColumnType("int(7)")
                    .HasColumnName("id");
                entity.Property(e => e.IloscDni)
                    .HasColumnType("int(11)")
                    .HasColumnName("ilosc_dni");
                entity.Property(e => e.SredniUtarg).HasColumnName("sredni_utarg");
                entity.Property(e => e.SredniZysk).HasColumnName("sredni_zysk");
                entity.Property(e => e.Sva).HasColumnName("SVA");
                entity.Property(e => e.Svb).HasColumnName("SVB");
                entity.Property(e => e.Svc).HasColumnName("SVC");
                entity.Property(e => e.Svd).HasColumnName("SVD");
                entity.Property(e => e.Sve).HasColumnName("SVE");
                entity.Property(e => e.Svf).HasColumnName("SVF");
                entity.Property(e => e.Svg).HasColumnName("SVG");
                entity.Property(e => e.UtargBrutto).HasColumnName("utarg_brutto");
                entity.Property(e => e.Zysk).HasColumnName("zysk");
            });

            modelBuilder.Entity<RaportRoczny>(entity =>
            {
                entity.HasKey(e => e.Miesiac).HasName("PRIMARY");

                entity
                    .ToTable("raport_roczny")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Miesiac)
                    .HasMaxLength(10)
                    .HasColumnName("miesiac");
                entity.Property(e => e.Id)
                    .HasColumnType("int(4)")
                    .HasColumnName("id");
                entity.Property(e => e.Sva).HasColumnName("SVA");
                entity.Property(e => e.Svb).HasColumnName("SVB");
                entity.Property(e => e.Svc).HasColumnName("SVC");
                entity.Property(e => e.Svd).HasColumnName("SVD");
                entity.Property(e => e.Sve).HasColumnName("SVE");
                entity.Property(e => e.Svf).HasColumnName("SVF");
                entity.Property(e => e.Svg).HasColumnName("SVG");
                entity.Property(e => e.UtargBrutto).HasColumnName("utarg_brutto");
                entity.Property(e => e.Zysk).HasColumnName("zysk");
            });

            modelBuilder.Entity<SerwisItem>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("serwis_items");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.DataAktualizacji)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp")
                    .HasColumnName("data_aktualizacji");
                entity.Property(e => e.DataOddaniaNaSerwis).HasColumnName("data_oddania_na_serwis");
                entity.Property(e => e.DataSprzedazy).HasColumnName("data_sprzedazy");
                entity.Property(e => e.DataUtworzenia)
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp")
                    .HasColumnName("data_utworzenia");
                entity.Property(e => e.DataZakupu).HasColumnName("data_zakupu");
                entity.Property(e => e.DokumentSprzedazy)
                    .HasMaxLength(255)
                    .HasColumnName("dokument_sprzedazy");
                entity.Property(e => e.DokumentZakupu)
                    .HasMaxLength(255)
                    .HasColumnName("dokument_zakupu");
                entity.Property(e => e.Komentarz)
                    .HasColumnType("text")
                    .HasColumnName("komentarz");
                entity.Property(e => e.NazwaProduktu)
                    .HasMaxLength(255)
                    .HasColumnName("nazwa_produktu");
                entity.Property(e => e.NumerRma)
                    .HasMaxLength(50)
                    .HasColumnName("numer_rma");
                entity.Property(e => e.NumerSeryjny)
                    .HasMaxLength(100)
                    .HasColumnName("numer_seryjny");
                entity.Property(e => e.TelefonKlienta)
                    .HasMaxLength(20)
                    .HasColumnName("telefon_klienta");
            });

            modelBuilder.Entity<Sprzedaz>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("sprzedaz")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(25)")
                    .HasColumnName("id");
                entity.Property(e => e.Cena).HasColumnName("cena");
                entity.Property(e => e.CenaNetto).HasColumnName("cena_netto");
                entity.Property(e => e.Czas)
                    .HasMaxLength(15)
                    .HasColumnName("czas");
                entity.Property(e => e.Data)
                    .HasMaxLength(15)
                    .HasColumnName("data");
                entity.Property(e => e.DataZakupu)
                    .HasMaxLength(20)
                    .HasColumnName("data_zakupu");
                entity.Property(e => e.FormaPlatnosci)
                    .HasMaxLength(35)
                    .HasColumnName("forma_platnosci");
                entity.Property(e => e.Ilosc).HasColumnName("ilosc");
                entity.Property(e => e.KodProduktu)
                    .HasMaxLength(25)
                    .HasColumnName("KOD_PRODUKTU");
                entity.Property(e => e.Nazwa)
                    .HasMaxLength(150)
                    .HasColumnName("nazwa");
                entity.Property(e => e.NumerFv)
                    .HasMaxLength(150)
                    .HasColumnName("numer_fv");
                entity.Property(e => e.RoznicaVat).HasColumnName("roznica_vat");
                entity.Property(e => e.StawkaVat)
                    .HasMaxLength(3)
                    .HasColumnName("stawka_vat");
                entity.Property(e => e.Zarobek).HasColumnName("zarobek");
            });

            modelBuilder.Entity<Stan>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("stan")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.HasIndex(e => e.Cena, "cena");

                entity.HasIndex(e => e.Ilosc, "ilosc");

                entity.HasIndex(e => e.Nazwa, "nazwa");

                entity.Property(e => e.Id)
                    .HasColumnType("int(25)")
                    .HasColumnName("id");
                entity.Property(e => e.Cena).HasColumnName("cena");
                entity.Property(e => e.CenaNetto).HasColumnName("cena_netto");
                entity.Property(e => e.DataZakupu)
                    .HasMaxLength(20)
                    .HasColumnName("data_zakupu");
                entity.Property(e => e.Gtu)
                    .HasMaxLength(4)
                    .HasColumnName("GTU");
                entity.Property(e => e.Ilosc).HasColumnName("ilosc");
                entity.Property(e => e.IloscWOpakowanju).HasColumnName("ilosc_w_opakowanju");
                entity.Property(e => e.KodKreskowy)
                    .HasMaxLength(25)
                    .HasColumnName("kod_kreskowy");
                entity.Property(e => e.KodProduktu)
                    .HasMaxLength(25)
                    .HasColumnName("KOD_PRODUKTU");
                entity.Property(e => e.KursEuro).HasColumnName("kurs_euro");
                entity.Property(e => e.KursUsd).HasColumnName("kurs_usd");
                entity.Property(e => e.Nazwa)
                    .HasMaxLength(150)
                    .HasColumnName("nazwa")
                    .UseCollation("cp1250_polish_ci")
                    .HasCharSet("cp1250");
                entity.Property(e => e.NettoZakup).HasColumnName("netto_zakup");
                entity.Property(e => e.NumerFv)
                    .HasMaxLength(150)
                    .HasColumnName("numer_fv");
                entity.Property(e => e.RoznicaVat).HasColumnName("roznica_vat");
                entity.Property(e => e.StawkaVat)
                    .HasMaxLength(4)
                    .HasColumnName("stawka_vat")
                    .UseCollation("utf8mb3_general_ci");
                entity.Property(e => e.Zarobek).HasColumnName("zarobek");
            });

            modelBuilder.Entity<StawkiVat>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("stawki_vat")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_unicode_ci");

                entity.Property(e => e.Sva)
                    .HasColumnType("int(3)")
                    .HasColumnName("SVA");
                entity.Property(e => e.Svb)
                    .HasColumnType("int(3)")
                    .HasColumnName("SVB");
                entity.Property(e => e.Svc)
                    .HasColumnType("int(3)")
                    .HasColumnName("SVC");
                entity.Property(e => e.Svd)
                    .HasColumnType("int(3)")
                    .HasColumnName("SVD");
                entity.Property(e => e.Sve)
                    .HasColumnType("int(3)")
                    .HasColumnName("SVE");
                entity.Property(e => e.Svf)
                    .HasColumnType("int(3)")
                    .HasColumnName("SVF");
                entity.Property(e => e.Svg)
                    .HasColumnType("int(3)")
                    .HasColumnName("SVG");
            });

            modelBuilder.Entity<Tusluga>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("TUsluga");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Nazwa).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("users")
                    .HasCharSet("latin2")
                    .UseCollation("latin2_general_ci");

                entity.HasIndex(e => e.Email, "email");

                entity.Property(e => e.Id)
                    .HasColumnType("int(5)")
                    .HasColumnName("id");
                entity.Property(e => e.Data)
                    .HasMaxLength(25)
                    .HasColumnName("data");
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");
                entity.Property(e => e.Haslo)
                    .HasMaxLength(100)
                    .HasColumnName("haslo");
                entity.Property(e => e.ImieNazwisko)
                    .HasMaxLength(150)
                    .HasColumnName("Imie_nazwisko");
                entity.Property(e => e.Login)
                    .HasMaxLength(35)
                    .HasColumnName("login");
                entity.Property(e => e.Ranga).HasMaxLength(25);
            });

            modelBuilder.Entity<Wystawca>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("wystawca")
                    .HasCharSet("latin2")
                    .UseCollation("latin2_general_ci");

                entity.HasIndex(e => e.Nip, "NIPIndex").IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(25)")
                    .HasColumnName("id");
                entity.Property(e => e.Bdo)
                    .HasMaxLength(25)
                    .HasColumnName("BDO");
                entity.Property(e => e.Email)
                    .HasMaxLength(120)
                    .HasColumnName("email");
                entity.Property(e => e.Gmina).HasMaxLength(50);
                entity.Property(e => e.KasfCzyWysylac).HasColumnName("kasf_czy_wysylac");
                entity.Property(e => e.Miasto)
                    .HasMaxLength(60)
                    .HasColumnName("miasto");
                entity.Property(e => e.MiejsceWystawienia)
                    .HasMaxLength(60)
                    .HasColumnName("miejsce_wystawienia");
                entity.Property(e => e.Nazwa)
                    .HasMaxLength(150)
                    .HasColumnName("nazwa");
                entity.Property(e => e.NazwaBanku)
                    .HasMaxLength(25)
                    .HasColumnName("nazwa_banku");
                entity.Property(e => e.Nip)
                    .HasMaxLength(15)
                    .HasColumnName("nip");
                entity.Property(e => e.NrKontaBankowego)
                    .HasMaxLength(40)
                    .HasColumnName("nr_konta_bankowego");
                entity.Property(e => e.Powiat).HasMaxLength(50);
                entity.Property(e => e.Regon).HasMaxLength(25);
                entity.Property(e => e.Telefon)
                    .HasMaxLength(15)
                    .HasColumnName("telefon");
                entity.Property(e => e.Ulica)
                    .HasMaxLength(60)
                    .HasColumnName("ulica");
                entity.Property(e => e.Waluta).HasMaxLength(5);
                entity.Property(e => e.Wojewodztwo).HasMaxLength(50);
                entity.Property(e => e.Wystawil)
                    .HasMaxLength(45)
                    .HasColumnName("wystawil");
            });
            
            }

    

        }
    }
