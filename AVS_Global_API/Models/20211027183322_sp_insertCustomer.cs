using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AVS_Global_API.Models
{
    public partial class sp_insertCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    IdNat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nationality = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BitActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__National__0DD1BD9D38236858", x => x.IdNat);
                });

            migrationBuilder.CreateTable(
                name: "tb_avs_security_options",
                columns: table => new
                {
                    IdCon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    KeyAcc = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    BitActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_avs_s__0FA7F29554ACA670", x => x.IdCon);
                });

            migrationBuilder.CreateTable(
                name: "tb_cat_countries",
                columns: table => new
                {
                    IdCatCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BitActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_cat_c__4DE1A84C90C607A9", x => x.IdCatCountry);
                });

            migrationBuilder.CreateTable(
                name: "tb_countries",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateOfEntry = table.Column<DateTime>(type: "datetime", nullable: true),
                    BitActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_count__F99F104DCFDE2AE5", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "tb_roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BitActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_roles__2A49584C0E1E7FA4", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "tb_status_forms",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BitActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_statu__B450643A87EF6ED8", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "tb_types_passports",
                columns: table => new
                {
                    IdTypePass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypePass = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BitActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_types__562BAF6D2C851CAE", x => x.IdTypePass);
                });

            migrationBuilder.CreateTable(
                name: "tb_convictions_travel",
                columns: table => new
                {
                    IdConviction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTravel = table.Column<int>(type: "int", nullable: true),
                    DateConvict = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IdCatCountry = table.Column<int>(type: "int", nullable: true),
                    Offence = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Sentence = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_convi__BB66B6C10ACED89B", x => x.IdConviction);
                    table.ForeignKey(
                        name: "FK__tb_convic__Sente__70DDC3D8",
                        column: x => x.IdCatCountry,
                        principalTable: "tb_cat_countries",
                        principalColumn: "IdCatCountry",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_deported_travel",
                columns: table => new
                {
                    IdDeport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTravel = table.Column<int>(type: "int", nullable: true),
                    DateDeport = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IdCatCountry = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ReferenceNum = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_depor__98DD67CA34F748FB", x => x.IdDeport);
                    table.ForeignKey(
                        name: "FK__tb_deport__Refer__6E01572D",
                        column: x => x.IdCatCountry,
                        principalTable: "tb_cat_countries",
                        principalColumn: "IdCatCountry",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_customersAVS",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCountry = table.Column<int>(type: "int", nullable: true),
                    RegisteredMail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DateOfEntry = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateValidity = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_custo__DB43864A360AF245", x => x.IdCustomer);
                    table.ForeignKey(
                        name: "FK__tb_custom__IdCou__4222D4EF",
                        column: x => x.IdCountry,
                        principalTable: "tb_countries",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    KeyAccess = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Seed = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Pass = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateOfEntry = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateValidity = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_users__B7C92638C411223F", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK__tb_users__IdRol__3F466844",
                        column: x => x.IdRol,
                        principalTable: "tb_roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_formularies",
                columns: table => new
                {
                    IdForm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCountry = table.Column<int>(type: "int", nullable: true),
                    IdCustomer = table.Column<int>(type: "int", nullable: true),
                    IdStatus = table.Column<int>(type: "int", nullable: true),
                    DateOfEntry = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_formu__007D03D9C6710911", x => x.IdForm);
                    table.ForeignKey(
                        name: "FK__tb_formul__IdCou__4AB81AF0",
                        column: x => x.IdCountry,
                        principalTable: "tb_countries",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tb_formul__IdCus__4BAC3F29",
                        column: x => x.IdCustomer,
                        principalTable: "tb_customersAVS",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tb_formul__IdSta__4CA06362",
                        column: x => x.IdStatus,
                        principalTable: "tb_status_forms",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Url_activation",
                columns: table => new
                {
                    IdUrl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<int>(type: "int", nullable: true),
                    ValueUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__tb_Url_ac__IdCus__440B1D61",
                        column: x => x.IdCustomer,
                        principalTable: "tb_customersAVS",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_conctactDetails",
                columns: table => new
                {
                    IdConctact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForm = table.Column<int>(type: "int", nullable: true),
                    IdCatCountry = table.Column<int>(type: "int", nullable: true),
                    TelHome = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TelWork = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BitSponsor = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_conct__FE86941A3F0EAD1D", x => x.IdConctact);
                    table.ForeignKey(
                        name: "FK__tb_concta__BitSp__5629CD9C",
                        column: x => x.IdForm,
                        principalTable: "tb_formularies",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tb_concta__IdCat__571DF1D5",
                        column: x => x.IdCatCountry,
                        principalTable: "tb_cat_countries",
                        principalColumn: "IdCatCountry",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_family_details",
                columns: table => new
                {
                    IdFam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForm = table.Column<int>(type: "int", nullable: true),
                    NMother = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NPather = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdNatMother = table.Column<int>(type: "int", nullable: true),
                    IdNatFather = table.Column<int>(type: "int", nullable: true),
                    SpouseName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IdNatSpouse = table.Column<int>(type: "int", nullable: true),
                    DateBirth = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    PlaceBirth = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Profesion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    InfoEmployerSpouse = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    BitChildrens = table.Column<bool>(type: "bit", nullable: true),
                    BitAcompany = table.Column<bool>(type: "bit", nullable: true),
                    BitAccountBank = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_famil__0FE27A0CC5BBB0E7", x => x.IdFam);
                    table.ForeignKey(
                        name: "FK__tb_family__BitAc__5FB337D6",
                        column: x => x.IdForm,
                        principalTable: "tb_formularies",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_passportDetails",
                columns: table => new
                {
                    IdPassport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForm = table.Column<int>(type: "int", nullable: true),
                    IdTypePass = table.Column<int>(type: "int", nullable: true),
                    TravelDocs = table.Column<bool>(type: "bit", nullable: true),
                    PassportNumber = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PlaceOfIssue = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DateOfIssue = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DateOfExpiry = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IssuingAuth = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DateOfChange = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_passp__BAAF27F74E7C5F5F", x => x.IdPassport);
                    table.ForeignKey(
                        name: "FK__tb_passpo__DateO__534D60F1",
                        column: x => x.IdForm,
                        principalTable: "tb_formularies",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_pastJobs",
                columns: table => new
                {
                    IdpJob = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForm = table.Column<int>(type: "int", nullable: true),
                    Designation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Depto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DateStart = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DateFinish = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Duties = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DescAddContr = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_pastJ__AC33AD230C5DEFBC", x => x.IdpJob);
                    table.ForeignKey(
                        name: "FK__tb_pastJo__IdFor__5CD6CB2B",
                        column: x => x.IdForm,
                        principalTable: "tb_formularies",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_personalData",
                columns: table => new
                {
                    IdPD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForm = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DateBirth = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CityBirth = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IdCatCountry = table.Column<int>(type: "int", nullable: true),
                    TypeSex = table.Column<bool>(type: "bit", nullable: true),
                    BloodGroup = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<bool>(type: "bit", nullable: true),
                    IdMark = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TypeNationality = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DetailOfProfesion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Religion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateOfChange = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_perso__B7703B3FCDDDEE11", x => x.IdPD);
                    table.ForeignKey(
                        name: "FK__tb_person__IdCat__5070F446",
                        column: x => x.IdCatCountry,
                        principalTable: "tb_cat_countries",
                        principalColumn: "IdCatCountry",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tb_person__IdFor__4F7CD00D",
                        column: x => x.IdForm,
                        principalTable: "tb_formularies",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_travel_history",
                columns: table => new
                {
                    IdTravel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForm = table.Column<int>(type: "int", nullable: true),
                    BitVisPakistan = table.Column<bool>(type: "bit", nullable: true),
                    BitVisCountries = table.Column<bool>(type: "bit", nullable: true),
                    BitVisRefused = table.Column<bool>(type: "bit", nullable: true),
                    BitRefusedPakistan = table.Column<bool>(type: "bit", nullable: true),
                    DescRefused = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DateTravel = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Purpose = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Duration = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BitRemoveCountry = table.Column<bool>(type: "bit", nullable: true),
                    BitConviction = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_trave__FF923C231E8C1BCE", x => x.IdTravel);
                    table.ForeignKey(
                        name: "FK__tb_travel__IdFor__6B24EA82",
                        column: x => x.IdForm,
                        principalTable: "tb_formularies",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_sponsors",
                columns: table => new
                {
                    IdSponsor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConctact = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TelPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TelHome = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TelWork = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_spons__9804FEEF0B3FB971", x => x.IdSponsor);
                    table.ForeignKey(
                        name: "FK__tb_sponso__IdCon__59FA5E80",
                        column: x => x.IdConctact,
                        principalTable: "tb_conctactDetails",
                        principalColumn: "IdConctact",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_acompanying_family",
                columns: table => new
                {
                    IdAcomp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFam = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    PassportNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_acomp__73BF010EF2BEAC76", x => x.IdAcomp);
                    table.ForeignKey(
                        name: "FK__tb_acompa__Addre__656C112C",
                        column: x => x.IdFam,
                        principalTable: "tb_family_details",
                        principalColumn: "IdFam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_bank_family",
                columns: table => new
                {
                    IdBank = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFam = table.Column<int>(type: "int", nullable: true),
                    NameBank = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Branch = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ACNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    VerifierDetails = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_bank___3EA5E6846502C30A", x => x.IdBank);
                    table.ForeignKey(
                        name: "FK__tb_bank_f__IdFam__68487DD7",
                        column: x => x.IdFam,
                        principalTable: "tb_family_details",
                        principalColumn: "IdFam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_childrens_familiy",
                columns: table => new
                {
                    IdChild = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFam = table.Column<int>(type: "int", nullable: true),
                    NameChild = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateOfBith = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_child__F287C37AB7B5F93F", x => x.IdChild);
                    table.ForeignKey(
                        name: "FK__tb_childr__IdFam__628FA481",
                        column: x => x.IdFam,
                        principalTable: "tb_family_details",
                        principalColumn: "IdFam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_acompanying_family_IdFam",
                table: "tb_acompanying_family",
                column: "IdFam");

            migrationBuilder.CreateIndex(
                name: "IX_tb_bank_family_IdFam",
                table: "tb_bank_family",
                column: "IdFam");

            migrationBuilder.CreateIndex(
                name: "IX_tb_childrens_familiy_IdFam",
                table: "tb_childrens_familiy",
                column: "IdFam");

            migrationBuilder.CreateIndex(
                name: "IX_tb_conctactDetails_IdCatCountry",
                table: "tb_conctactDetails",
                column: "IdCatCountry");

            migrationBuilder.CreateIndex(
                name: "IX_tb_conctactDetails_IdForm",
                table: "tb_conctactDetails",
                column: "IdForm");

            migrationBuilder.CreateIndex(
                name: "IX_tb_convictions_travel_IdCatCountry",
                table: "tb_convictions_travel",
                column: "IdCatCountry");

            migrationBuilder.CreateIndex(
                name: "IX_tb_customersAVS_IdCountry",
                table: "tb_customersAVS",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_tb_deported_travel_IdCatCountry",
                table: "tb_deported_travel",
                column: "IdCatCountry");

            migrationBuilder.CreateIndex(
                name: "IX_tb_family_details_IdForm",
                table: "tb_family_details",
                column: "IdForm");

            migrationBuilder.CreateIndex(
                name: "IX_tb_formularies_IdCountry",
                table: "tb_formularies",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_tb_formularies_IdCustomer",
                table: "tb_formularies",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_tb_formularies_IdStatus",
                table: "tb_formularies",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_tb_passportDetails_IdForm",
                table: "tb_passportDetails",
                column: "IdForm");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pastJobs_IdForm",
                table: "tb_pastJobs",
                column: "IdForm");

            migrationBuilder.CreateIndex(
                name: "IX_tb_personalData_IdCatCountry",
                table: "tb_personalData",
                column: "IdCatCountry");

            migrationBuilder.CreateIndex(
                name: "IX_tb_personalData_IdForm",
                table: "tb_personalData",
                column: "IdForm");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sponsors_IdConctact",
                table: "tb_sponsors",
                column: "IdConctact");

            migrationBuilder.CreateIndex(
                name: "IX_tb_travel_history_IdForm",
                table: "tb_travel_history",
                column: "IdForm");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Url_activation_IdCustomer",
                table: "tb_Url_activation",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_IdRol",
                table: "tb_users",
                column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "tb_acompanying_family");

            migrationBuilder.DropTable(
                name: "tb_avs_security_options");

            migrationBuilder.DropTable(
                name: "tb_bank_family");

            migrationBuilder.DropTable(
                name: "tb_childrens_familiy");

            migrationBuilder.DropTable(
                name: "tb_convictions_travel");

            migrationBuilder.DropTable(
                name: "tb_deported_travel");

            migrationBuilder.DropTable(
                name: "tb_passportDetails");

            migrationBuilder.DropTable(
                name: "tb_pastJobs");

            migrationBuilder.DropTable(
                name: "tb_personalData");

            migrationBuilder.DropTable(
                name: "tb_sponsors");

            migrationBuilder.DropTable(
                name: "tb_travel_history");

            migrationBuilder.DropTable(
                name: "tb_types_passports");

            migrationBuilder.DropTable(
                name: "tb_Url_activation");

            migrationBuilder.DropTable(
                name: "tb_users");

            migrationBuilder.DropTable(
                name: "tb_family_details");

            migrationBuilder.DropTable(
                name: "tb_conctactDetails");

            migrationBuilder.DropTable(
                name: "tb_roles");

            migrationBuilder.DropTable(
                name: "tb_formularies");

            migrationBuilder.DropTable(
                name: "tb_cat_countries");

            migrationBuilder.DropTable(
                name: "tb_customersAVS");

            migrationBuilder.DropTable(
                name: "tb_status_forms");

            migrationBuilder.DropTable(
                name: "tb_countries");
        }
    }
}
