CREATE TABLE Nationalities
(
	IdNat			INT PRIMARY KEY IDENTITY(1, 1),
	Nationality		VARCHAR(100),
	BitActive		BIT
)


CREATE TABLE tb_cat_countries
(
	IdCatCountry	INT PRIMARY KEY IDENTITY(1, 1),
	Country			VARCHAR(100),
	BitActive		BIT
)


CREATE TABLE tb_roles
(
	IdRol		INT PRIMARY KEY IDENTITY(1,1),
	NameRol		VARCHAR(50),
	BitActive	BIT
)


CREATE TABLE tb_users
(
	IdUser			INT PRIMARY KEY IDENTITY(1,1),
	IdRol			INT,
	Name			VARCHAR(100),
	LastName		VARCHAR(100),
	Age				INT,
	KeyAccess		VARCHAR(100),
	Seed			VARBINARY(MAX),
	Pass			VARBINARY(MAX),
	DateOfEntry		DATETIME,
	DateValidity	DATETIME,

	FOREIGN KEY (IdRol) REFERENCES tb_roles(IdRol)
)

CREATE TABLE tb_customersAVS
(
	IdCustomer		INT PRIMARY KEY IDENTITY(1,1),
	IdCountry		INT,
	RegisteredMail	VARCHAR(100),
	Pass			VARBINARY(MAX),
	Seed			VARCHAR(100),
	DateOfEntry		DATETIME,
	DateValidity	DATETIME,
	
	FOREIGN KEY (IdCountry) REFERENCES tb_countries(IdCountry)

)


CREATE TABLE tb_Url_activation
(
	IdUrl		INT IDENTITY(1, 1),
	IdCustomer	INT,
	ValueUrl	VARCHAR(100),
	Active		BIT,

	FOREIGN KEY (IdCustomer) REFERENCES tb_customersAVS(IdCustomer)
)


CREATE TABLE tb_status_forms
(
	IdStatus	INT PRIMARY KEY IDENTITY(1,1),
	Description	VARCHAR(50),
	BitActive	BIT
)



CREATE TABLE tb_types_passports
(
	IdTypePass	INT PRIMARY KEY IDENTITY(1,1),
	TypePass	VARCHAR(100),
	BitActive	BIT
)



CREATE TABLE tb_formularies
(
	IdForm			INT PRIMARY KEY IDENTITY(1,1),
	IdCountry		INT,
	IdCustomer		INT,
	IdStatus		INT,
	DateOfEntry		DATETIME,

	FOREIGN KEY (IdCountry) REFERENCES tb_countries(IdCountry),
	FOREIGN KEY (IdCustomer) REFERENCES tb_customersAVS(IdCustomer),
	FOREIGN KEY (IdStatus) REFERENCES tb_status_forms(IdStatus)

)

CREATE TABLE tb_personalData
(
	IdPD				INT PRIMARY KEY IDENTITY(1,1),
	IdForm				INT,
	Name				VARCHAR(100),
	MiddleName			VARCHAR(100),
	LastName			VARCHAR(100),
	DateBirth			VARCHAR(10),
	CityBirth			VARCHAR(100),
	IdCatCountry		INT,
	TypeSex				BIT,
	BloodGroup			VARCHAR(50),
	MaritalStatus		BIT,
	IdMark				VARCHAR(50),
	TypeNationality		VARCHAR(50),
	DetailOfProfesion	VARCHAR(200),
	Religion			VARCHAR(50),
	DateOfChange		DATETIME,

	FOREIGN KEY (IdForm) REFERENCES tb_formularies(IdForm),
	FOREIGN KEY (IdCatCountry) REFERENCES tb_cat_countries(IdCatCountry)
)

CREATE TABLE tb_passportDetails
(
	IdPassport		INT PRIMARY KEY IDENTITY(1,1),
	IdForm			INT,
	IdTypePass		INT,
	TravelDocs		BIT,
	PassportNumber	VARCHAR(100),
	PlaceOfIssue	VARCHAR(100),
	DateOfIssue		VARCHAR(10),
	DateOfExpiry	VARCHAR(10),
	IssuingAuth		VARCHAR(100),
	DateOfChange	DATETIME

	FOREIGN KEY (IdForm) REFERENCES tb_formularies(IdForm)
)

CREATE TABLE tb_conctactDetails
(
	IdConctact		INT PRIMARY KEY IDENTITY(1, 1),
	IdForm			INT,
	IdCatCountry	INT,
	TelHome			VARCHAR(20),
	TelWork			VARCHAR(20),
	Email			VARCHAR(50),
	BitSponsor		BIT

	FOREIGN KEY (IdForm) REFERENCES tb_formularies(IdForm),
	FOREIGN KEY (IdCatCountry) REFERENCES tb_cat_countries(IdCatCountry)
)


CREATE TABLE tb_sponsors
(
	IdSponsor	INT PRIMARY KEY IDENTITY(1, 1),
	IdConctact	INT,
	Name		VARCHAR(50),
	Address		VARCHAR(100),
	TelPhone	VARCHAR(20),
	TelHome		VARCHAR(20),
	TelWork		VARCHAR(20),

	FOREIGN KEY (IdConctact) REFERENCES tb_conctactDetails(IdConctact)
)

CREATE TABLE tb_pastJobs
(
	IdpJob			INT PRIMARY KEY IDENTITY(1,1),
	IdForm			INT,
	Designation		VARCHAR(100),
	Depto			VARCHAR(100),
	DateStart		VARCHAR(10),
	DateFinish		VARCHAR(10),
	Duties			VARCHAR(100),
	Address			VARCHAR(100),
	Phone			VARCHAR(20),
	DescAddContr	VARCHAR(200),

	FOREIGN KEY (IdForm) REFERENCES tb_formularies(IdForm)
)

CREATE TABLE tb_family_details
(
	IdFam				INT PRIMARY KEY IDENTITY(1,1),
	IdForm				INT,
	NMother				VARCHAR(50),
	NPather				VARCHAR(50),
	IdNatMother			INT,
	IdNatFather			INT,
	SpouseName			VARCHAR(100),
	IdNatSpouse			INT,
	DateBirth			VARCHAR(10),
	PlaceBirth			VARCHAR(100),
	Profesion			VARCHAR(100),
	InfoEmployerSpouse	VARCHAR(150),
	BitChildrens		BIT,
	BitAcompany			BIT,
	BitAccountBank		BIT

	FOREIGN KEY (IdForm) REFERENCES tb_formularies(IdForm)
)

CREATE TABLE tb_childrens_familiy
(
	IdChild		INT PRIMARY KEY IDENTITY(1, 1),
	IdFam		INT,
	NameChild	VARCHAR(50),
	DateOfBith	VARCHAR(10),

	FOREIGN KEY (IdFam) REFERENCES tb_family_details(IdFam)
)

CREATE TABLE tb_acompanying_family
(
	IdAcomp			INT PRIMARY KEY IDENTITY(1,1),
	IdFam			INT,
	FullName		VARCHAR(100),
	DateOfBirth		VARCHAR(10),
	PassportNumber	VARCHAR(10),
	Address			VARCHAR(100)

	FOREIGN KEY (IdFam) REFERENCES tb_family_details(IdFam)
)

CREATE TABLE tb_bank_family
(
	IdBank			INT PRIMARY KEY IDENTITY(1, 1),
	IdFam			INT,
	NameBank		VARCHAR(50),
	Branch			VARCHAR(10),
	ACNumber		VARCHAR(50),
	Address			VARCHAR(100),
	VerifierDetails	VARCHAR(100),

	FOREIGN KEY (IdFam) REFERENCES tb_family_details(IdFam)
)

CREATE TABLE tb_travel_history
(
	IdTravel			INT PRIMARY KEY IDENTITY(1,1 ),
	IdForm				INT,
	BitVisPakistan		BIT, --	VISITED PAKISTAN LAST 5 YEARS
	BitVisCountries		BIT, -- VISITED COUNTRIES LAS TWO YEARS FOR PAKISTAN ONLY
	BitVisRefused		BIT,
	BitRefusedPakistan	BIT,
	DescRefused			VARCHAR(200),
	DateTravel			VARCHAR(10),
	Address				VARCHAR(100),
	Purpose				VARCHAR(50),
	Duration			VARCHAR(50),
	BitRemoveCountry	BIT,
	BitConviction		BIT,

	FOREIGN KEY (IdForm) REFERENCES tb_formularies(IdForm)
	
)

CREATE TABLE tb_deported_travel
(
	IdDeport		INT PRIMARY KEY IDENTITY(1, 1),
	IdTravel		INT,
	DateDeport		VARCHAR(10),
	IdCatCountry	INT,
	Reason			VARCHAR(100),
	ReferenceNum	VARCHAR(20)

	FOREIGN KEY (IdCatCountry) REFERENCES tb_cat_countries(IdCatCountry)
)

CREATE TABLE tb_convictions_travel
(
	IdConviction	INT PRIMARY KEY IDENTITY(1, 1),
	IdTravel		INT,
	DateConvict		VARCHAR(10),
	IdCatCountry	INT,
	Offence			VARCHAR(100),
	Sentence		VARCHAR(20)

	FOREIGN KEY (IdCatCountry) REFERENCES tb_cat_countries(IdCatCountry)
)
