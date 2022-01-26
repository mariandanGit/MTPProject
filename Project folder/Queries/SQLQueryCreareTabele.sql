create table Admini(

	ID_Admini int not null identity(1,1) primary key,
	Nume varchar(30) not null,
	Prenume varchar(30) not null,
	Data_nastere date not null,
	Email varchar(50) not null,
	Parola varchar(255) not null,
);

create table Clienti(

	ID_Client int not null identity(1,1) primary key,
	Nume varchar(30) not null,
	Prenume varchar(30) not null,
	Data_nastere date not null,
	Telefon varchar(15) not null,
	Email varchar(50) not null,
	Adresa varchar(50) not null,
	Oras varchar(20) not null,
	Tara varchar(20) not null,

);

create table Locatii(

	ID_Locatie int not null identity(1,1) primary key,
	Nume varchar(50) not null,
	Adresa varchar(50) not null,
	Oras varchar(20) not null,
	Cod_postal varchar(10) not null,
);

create table Masini(

	ID_Masina int not null identity(1,1) primary key,
	Marca varchar(50) not null,
	Model varchar(50) not null,
	Categorie varchar(50) not null,
	Poza varchar(50) not null,
	Transmisie varchar(50) not null,
	Combustibil varchar(50) not null,
	Aer_conditionat bit,
	Nr_locuri int,
	Nr_bagaje int,
	Pret_per_zi float not null,
	Status varchar(50) not null,
	ID_Locatie int not null foreign key references Locatii(ID_Locatie),
);

create table Inchirieri(

	ID_Inchiriere int not null identity(1,1) primary key,
	Data_preluare date not null,
	Data_predare date not null,
	Cost float not null,
	Nume_asigurare varchar(50) not null,
	Tip_asigurare varchar(50) not null,
	Cost_asigurare float not null,
	Status varchar(50) not null,
	ID_Client int not null foreign key references Clienti(ID_Client),
	ID_Locatie_preluare int not null foreign key references Locatii(ID_Locatie),
	ID_Locatie_predare int not null foreign key references Locatii(ID_Locatie),
	ID_Masina int not null foreign key references Masini(ID_Masina),
);