use leasingAgency_BD
create database leasingAgency_BD
drop database leasingAgency_BD

drop table UserTable

drop table AutoTable

drop table LikedAuto

drop table LeasingApplications

create table UserTable
(
	IdUser int primary key identity(1, 1),
	UserLogin char(30) unique NOT NULL,
	UserPassword char(32) NOT NULL
)

create table AutoTable
(
	IdAuto int primary key identity(1, 1),
	BrandAuto char(50) NOT NULL,
	ModelAuto char(50) NOT NULL,
	BodyType char(50) NOT NULL,
	Release int NOT NULL,
	Color char(50) NOT NULL,
	Price int NOT NULL,
	DurationPayment int NOT NULl,
	MonthPayment int NOT NULL,
	ImgAuto nvarchar(MAX) NOT NULL,
)

CREATE TABLE LikedAuto
( 
    IdUser integer NOT NULL,
    IdAuto integer  NOT NULL,
    PRIMARY KEY (IdUser , IdAuto ),
    FOREIGN KEY (IdUser) REFERENCES UserTable,
    FOREIGN KEY (IdAuto ) REFERENCES AutoTable,
);

CREATE TABLE LeasingApplications
( 
	IdUser integer  NOT NULL,
	PhoneNumber char(9) NOT NULL,
	Surname char(20) NOT NULL,
	Name char(20) NOT NULL,
	MiddleName char(20) NOT NULL,
	DataApplications date NOT NULL,
    PRIMARY KEY (IdUser),
    FOREIGN KEY (IdUser) REFERENCES UserTable,
);

select * from UserTable;

select * from AutoTable;
