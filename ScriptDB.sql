CREATE TABLE tb_status_forms
(
	IdStatus	INT PRIMARY KEY IDENTITY(1,1),
	Description	VARCHAR(50),
	BitActive	BIT
)


CREATE TABLE tb_roles
(
	IdRol		INT PRIMARY KEY IDENTITY(1,1),
	NameRol		VARCHAR(50),
	BitActive	BIT
)

CREATE TABLE tb_types_passports
(
	IdTypePass	INT PRIMARY KEY IDENTITY(1,1),
	TypePass	VARCHAR(100),
	BitActive	BIT
)

CREATE TABLE tb_users
(
	IdUser			INT PRIMARY KEY IDENTITY(1,1),
	Name			VARCHAR(100),
	LastName		VARCHAR(100),
	Age				INT,
	KeyAccess		VARCHAR(100),
	Seed			VARBINARY(MAX),
	Pass			VARBINARY(MAX),
	DateOfEntry		DATETIME,
	DateValidity	DATETIME,
	IdRol			INT
)



CREATE TABLE tb_customersAVS
(
	IdCustomer		INT PRIMARY KEY IDENTITY(1,1),
	IdCountry		INT,
	RegisteredMail	VARCHAR(100),
	Pass			VARBINARY(MAX),
	Seed			VARCHAR(100),
	DateOfEntry		DATETIME,
	DateValidity	DATETIME
	
)


CREATE TABLE tb_formularies
(
	IdForm			INT PRIMARY KEY IDENTITY(1,1),
	IdCountry		INT,
	IdCustomer		INT,
	IdStatus		INT,
	DateOfEntry		DATETIME
)

CREATE TABLE tb_personalData
(
	IdPD			INT PRIMARY KEY IDENTITY(1,1),
	IdForm			INT,
	Name			VARCHAR(100),
	MiddleName		VARCHAR(100),
	LastName		VARCHAR(100),
	DateBirth		VARCHAR(10),
	CityBirth		VARCHAR(100),
	CountryBirth	VARCHAR(50),
	TypeSex			BIT,
	BloodGroup		VARCHAR(50),
	MaritalStatus	BIT,
	IdMark			VARCHAR(50),
	TypeNationality	VARCHAR(50),
	Religion		VARCHAR(50),
	DateOfChange	DATETIME
)

CREATE TABLE tb_passportDetails
(
	IdPassport		INT PRIMARY KEY IDENTITY(1,1),
	IdPD			INT,
	IdTypePass		INT,
	TravelDocs		BIT,
	PassportNumber	VARCHAR(100),
	PlaceOfIssue	VARCHAR(100),
	DateOfIssue		VARCHAR(10),
	DateOfExpiry	VARCHAR(10),
	IssuingAuth		VARCHAR(100),
	DateOfChange	DATETIME
)
