using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class AVS_DBContext : DbContext
    {
        public AVS_DBContext()
        {
        }

        public AVS_DBContext(DbContextOptions<AVS_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<TbAcompanyingFamily> TbAcompanyingFamilies { get; set; }
        public virtual DbSet<TbAvsSecurityOption> TbAvsSecurityOptions { get; set; }
        public virtual DbSet<TbBankFamily> TbBankFamilies { get; set; }
        public virtual DbSet<TbCatCountry> TbCatCountries { get; set; }
        public virtual DbSet<TbCatTypesVisa> TbCatTypesVisas { get; set; }
        public virtual DbSet<TbCatTypesVisasApplied> TbCatTypesVisasApplieds { get; set; }
        public virtual DbSet<TbCatVisasTime> TbCatVisasTimes { get; set; }
        public virtual DbSet<TbChildrensFamiliy> TbChildrensFamiliys { get; set; }
        public virtual DbSet<TbConctactDetail> TbConctactDetails { get; set; }
        public virtual DbSet<TbConvictionsTravel> TbConvictionsTravels { get; set; }
        public virtual DbSet<TbCountry> TbCountries { get; set; }
        public virtual DbSet<TbCustomersAv> TbCustomersAvs { get; set; }
        public virtual DbSet<TbDeportedTravel> TbDeportedTravels { get; set; }
        public virtual DbSet<TbFamilyDetail> TbFamilyDetails { get; set; }
        public virtual DbSet<TbFormulary> TbFormularies { get; set; }
        public virtual DbSet<TbPassportDetail> TbPassportDetails { get; set; }
        public virtual DbSet<TbPastJob> TbPastJobs { get; set; }
        public virtual DbSet<TbPersonalDatum> TbPersonalData { get; set; }
        public virtual DbSet<TbRole> TbRoles { get; set; }
        public virtual DbSet<TbSponsor> TbSponsors { get; set; }
        public virtual DbSet<TbStatusForm> TbStatusForms { get; set; }
        public virtual DbSet<TbTravelHistory> TbTravelHistories { get; set; }
        public virtual DbSet<TbTypesPassport> TbTypesPassports { get; set; }
        public virtual DbSet<TbUrlActivation> TbUrlActivations { get; set; }
        public virtual DbSet<TbUser> TbUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LTW10JM3N493\\SQLEXPRESSEMG;Database=AVS_DB; User=sa;password=Xerox9010");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.HasKey(e => e.IdNat)
                    .HasName("PK__National__0DD1BD9D38236858");

                entity.Property(e => e.Nationality1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nationality");
            });

            modelBuilder.Entity<TbAcompanyingFamily>(entity =>
            {
                entity.HasKey(e => e.IdAcomp)
                    .HasName("PK__tb_acomp__73BF010EF2BEAC76");

                entity.ToTable("tb_acompanying_family");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFamNavigation)
                    .WithMany(p => p.TbAcompanyingFamilies)
                    .HasForeignKey(d => d.IdFam)
                    .HasConstraintName("FK__tb_acompa__Addre__656C112C");
            });

            modelBuilder.Entity<TbAvsSecurityOption>(entity =>
            {
                entity.HasKey(e => e.IdCon)
                    .HasName("PK__tb_avs_s__0FA7F29554ACA670");

                entity.ToTable("tb_avs_security_options");

                entity.Property(e => e.KeyAcc)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Value).IsUnicode(false);
            });

            modelBuilder.Entity<TbBankFamily>(entity =>
            {
                entity.HasKey(e => e.IdBank)
                    .HasName("PK__tb_bank___3EA5E6846502C30A");

                entity.ToTable("tb_bank_family");

                entity.Property(e => e.Acnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACNumber");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NameBank)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VerifierDetails)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFamNavigation)
                    .WithMany(p => p.TbBankFamilies)
                    .HasForeignKey(d => d.IdFam)
                    .HasConstraintName("FK__tb_bank_f__IdFam__68487DD7");
            });

            modelBuilder.Entity<TbCatCountry>(entity =>
            {
                entity.HasKey(e => e.IdCatCountry)
                    .HasName("PK__tb_cat_c__4DE1A84C90C607A9");

                entity.ToTable("tb_cat_countries");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCatTypesVisa>(entity =>
            {
                entity.HasKey(e => e.IdTypeVisa)
                    .HasName("PK__tb_cat_t__9617DA942C0C99BE");

                entity.ToTable("tb_cat_types_visas");

                entity.Property(e => e.TypeVisa)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCatTypesVisasApplied>(entity =>
            {
                entity.HasKey(e => e.IdVisaAp)
                    .HasName("PK__tb_cat_t__0C7581C4A5B7008A");

                entity.ToTable("tb_cat_types_visas_applied");

                entity.Property(e => e.TypeVisa)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCatVisasTime>(entity =>
            {
                entity.HasKey(e => e.IdVisasTime)
                    .HasName("PK__tb_cat_v__C0A4FF995176C523");

                entity.ToTable("tb_cat_visas_times");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbChildrensFamiliy>(entity =>
            {
                entity.HasKey(e => e.IdChild)
                    .HasName("PK__tb_child__F287C37AB7B5F93F");

                entity.ToTable("tb_childrens_familiy");

                entity.Property(e => e.DateOfBith)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NameChild)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFamNavigation)
                    .WithMany(p => p.TbChildrensFamiliys)
                    .HasForeignKey(d => d.IdFam)
                    .HasConstraintName("FK__tb_childr__IdFam__628FA481");
            });

            modelBuilder.Entity<TbConctactDetail>(entity =>
            {
                entity.HasKey(e => e.IdConctact)
                    .HasName("PK__tb_conct__FE86941A3F0EAD1D");

                entity.ToTable("tb_conctactDetails");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelHome)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelWork)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatCountryNavigation)
                    .WithMany(p => p.TbConctactDetails)
                    .HasForeignKey(d => d.IdCatCountry)
                    .HasConstraintName("FK__tb_concta__IdCat__571DF1D5");

                entity.HasOne(d => d.IdFormNavigation)
                    .WithMany(p => p.TbConctactDetails)
                    .HasForeignKey(d => d.IdForm)
                    .HasConstraintName("FK__tb_concta__BitSp__5629CD9C");
            });

            modelBuilder.Entity<TbConvictionsTravel>(entity =>
            {
                entity.HasKey(e => e.IdConviction)
                    .HasName("PK__tb_convi__BB66B6C10ACED89B");

                entity.ToTable("tb_convictions_travel");

                entity.Property(e => e.DateConvict)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Offence)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sentence)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatCountryNavigation)
                    .WithMany(p => p.TbConvictionsTravels)
                    .HasForeignKey(d => d.IdCatCountry)
                    .HasConstraintName("FK__tb_convic__Sente__70DDC3D8");
            });

            modelBuilder.Entity<TbCountry>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK__tb_count__F99F104DCFDE2AE5");

                entity.ToTable("tb_countries");

                entity.Property(e => e.DateOfEntry).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCustomersAv>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK__tb_custo__DB43864A360AF245");

                entity.ToTable("tb_customersAVS");

                entity.Property(e => e.DateOfEntry).HasColumnType("datetime");

                entity.Property(e => e.DateValidity).HasColumnType("datetime");

                entity.Property(e => e.Pass)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredMail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Seed)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.TbCustomersAvs)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK__tb_custom__IdCou__4222D4EF");
            });

            modelBuilder.Entity<TbDeportedTravel>(entity =>
            {
                entity.HasKey(e => e.IdDeport)
                    .HasName("PK__tb_depor__98DD67CA34F748FB");

                entity.ToTable("tb_deported_travel");

                entity.Property(e => e.DateDeport)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatCountryNavigation)
                    .WithMany(p => p.TbDeportedTravels)
                    .HasForeignKey(d => d.IdCatCountry)
                    .HasConstraintName("FK__tb_deport__Refer__6E01572D");
            });

            modelBuilder.Entity<TbFamilyDetail>(entity =>
            {
                entity.HasKey(e => e.IdFam)
                    .HasName("PK__tb_famil__0FE27A0CC5BBB0E7");

                entity.ToTable("tb_family_details");

                entity.Property(e => e.DateBirth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InfoEmployerSpouse)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nmother)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NMother");

                entity.Property(e => e.Npather)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NPather");

                entity.Property(e => e.PlaceBirth)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Profesion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFormNavigation)
                    .WithMany(p => p.TbFamilyDetails)
                    .HasForeignKey(d => d.IdForm)
                    .HasConstraintName("FK__tb_family__BitAc__5FB337D6");
            });

            modelBuilder.Entity<TbFormulary>(entity =>
            {
                entity.HasKey(e => e.IdForm)
                    .HasName("PK__tb_formu__007D03D9C6710911");

                entity.ToTable("tb_formularies");

                entity.Property(e => e.DateOfEntry).HasColumnType("datetime");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.TbFormularies)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK__tb_formul__IdCou__4AB81AF0");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.TbFormularies)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK__tb_formul__IdCus__4BAC3F29");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.TbFormularies)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__tb_formul__IdSta__4CA06362");
            });

            modelBuilder.Entity<TbPassportDetail>(entity =>
            {
                entity.HasKey(e => e.IdPassport)
                    .HasName("PK__tb_passp__BAAF27F74E7C5F5F");

                entity.ToTable("tb_passportDetails");

                entity.Property(e => e.DateOfChange).HasColumnType("datetime");

                entity.Property(e => e.DateOfExpiry)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfIssue)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssuingAuth)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceOfIssue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFormNavigation)
                    .WithMany(p => p.TbPassportDetails)
                    .HasForeignKey(d => d.IdForm)
                    .HasConstraintName("FK__tb_passpo__DateO__534D60F1");
            });

            modelBuilder.Entity<TbPastJob>(entity =>
            {
                entity.HasKey(e => e.IdpJob)
                    .HasName("PK__tb_pastJ__AC33AD230C5DEFBC");

                entity.ToTable("tb_pastJobs");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateFinish)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateStart)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Depto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescAddContr)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Duties)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFormNavigation)
                    .WithMany(p => p.TbPastJobs)
                    .HasForeignKey(d => d.IdForm)
                    .HasConstraintName("FK__tb_pastJo__IdFor__5CD6CB2B");
            });

            modelBuilder.Entity<TbPersonalDatum>(entity =>
            {
                entity.HasKey(e => e.IdPd)
                    .HasName("PK__tb_perso__B7703B3FCDDDEE11");

                entity.ToTable("tb_personalData");

                entity.Property(e => e.IdPd).HasColumnName("IdPD");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityBirth)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateBirth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfChange).HasColumnType("datetime");

                entity.Property(e => e.DetailOfProfesion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdMark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PortDeparture)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PortEntry)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PurposeOfVisit)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pvpakistan)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PVPakistan");

                entity.Property(e => e.Religion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeNationality)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatCountryNavigation)
                    .WithMany(p => p.TbPersonalData)
                    .HasForeignKey(d => d.IdCatCountry)
                    .HasConstraintName("FK__tb_person__IdCat__5070F446");

                entity.HasOne(d => d.IdFormNavigation)
                    .WithMany(p => p.TbPersonalData)
                    .HasForeignKey(d => d.IdForm)
                    .HasConstraintName("FK__tb_person__IdFor__4F7CD00D");
            });

            modelBuilder.Entity<TbRole>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__tb_roles__2A49584C0E1E7FA4");

                entity.ToTable("tb_roles");

                entity.Property(e => e.NameRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbSponsor>(entity =>
            {
                entity.HasKey(e => e.IdSponsor)
                    .HasName("PK__tb_spons__9804FEEF0B3FB971");

                entity.ToTable("tb_sponsors");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelHome)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelWork)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdConctactNavigation)
                    .WithMany(p => p.TbSponsors)
                    .HasForeignKey(d => d.IdConctact)
                    .HasConstraintName("FK__tb_sponso__IdCon__59FA5E80");
            });

            modelBuilder.Entity<TbStatusForm>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__tb_statu__B450643A87EF6ED8");

                entity.ToTable("tb_status_forms");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbTravelHistory>(entity =>
            {
                entity.HasKey(e => e.IdTravel)
                    .HasName("PK__tb_trave__FF923C231E8C1BCE");

                entity.ToTable("tb_travel_history");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateTravel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DescRefused)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Purpose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFormNavigation)
                    .WithMany(p => p.TbTravelHistories)
                    .HasForeignKey(d => d.IdForm)
                    .HasConstraintName("FK__tb_travel__IdFor__6B24EA82");
            });

            modelBuilder.Entity<TbTypesPassport>(entity =>
            {
                entity.HasKey(e => e.IdTypePass)
                    .HasName("PK__tb_types__562BAF6D2C851CAE");

                entity.ToTable("tb_types_passports");

                entity.Property(e => e.TypePass)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbUrlActivation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tb_Url_activation");

                entity.Property(e => e.IdUrl).ValueGeneratedOnAdd();

                entity.Property(e => e.ValueUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK__tb_Url_ac__IdCus__440B1D61");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__tb_users__B7C92638C411223F");

                entity.ToTable("tb_users");

                entity.Property(e => e.DateOfEntry).HasColumnType("datetime");

                entity.Property(e => e.DateValidity).HasColumnType("datetime");

                entity.Property(e => e.KeyAccess)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.TbUsers)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__tb_users__IdRol__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
