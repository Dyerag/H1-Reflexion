CREATE DATABASE Spooktober
GO

CREATE LOGIN "Pumpkin King" WITH PASSWORD = 'Sally'
CREATE LOGIN "Spookie Month" WITH PASSWORD = 'Dance'

USE Spooktober
GO

CREATE USER Jack FOR LOGIN [Pumpkin King]
CREATE USER Pelo FOR LOGIN [Spookie Month]

CREATE TABLE Ansatte(
	Fornavn nvarchar(64) not null,
	Efternavn nvarchar(64) not null,
	F�dselsdag DATE not null,
	"M�nedsl�n i kr." int not null,
	Ans�ttelsesdato date not null
);
GO

GRANT CONTROL ON Ansatte TO Jack
GRANT SELECT ON Ansatte TO Pelo

--Alt data laves af rng sider:
-- name = https://www.behindthename.com/random/
-- salary = den der dukker op p� google n�r man s�ger p� en rng generator. variationen er: 7000 - 35185
-- employementdate = https://www.random.org/calendar-dates/
INSERT INTO Ansatte(Fornavn, Efternavn, F�dselsdag, [M�nedsl�n i kr.], Ans�ttelsesdato)
VALUES 
	('Viktoria', 'Iversen', '1993/5/7', 31720, '2011/05/16'),
	('Asger', 'Brams', '1962/3/12', 12411, '1991/12/12'),
	('Christa', 'Bjarnesen', '1963/7/6', 32460,'1979/07/18'),
	('Tatiana', 'Steensen', '2001/2/17', 25102, '2021/08/09'),
	('Karsten', 'Lange', '1984/1/31', 9223, '2011/02/03'),
	('Bernt', 'Jokumsen', '1984/10/27', 28973, '2021/12/28'),
	('Pia', 'Dam', '1956/7/13', 23442, '2002/12/25'),
	('Gitte', 'Dalgaard', '1957/12/27', 32790, '2017/07/12'),
	('Birgitte', 'Steensen', '2000/2/23', 27404, '2021/03/17'),
	('Marius', 'Str�m', '2005/1/2', 7000, '2022/06/15'),
	('Thea', 'Andreassen', '2005/6/5', 7000, '2022/07/15'),
	('Vivian', 'Jokumsen', '1998/12/17', 10897, '2018/12/07'),
	('Orla', 'Olson', '2000/9/25', 13106, '2018/01/16'),
	('Rune', 'Strand', '1994/3/3', 17539, '2015/08/18'),
	('Catrine', 'Steffensen', '1967/7/15', 32392, '2020/12/03')

CREATE TABLE "Fulde navn"(
	"Navn" nvarchar(128) PRIMARY KEY not null 
);

GRANT CONTROL ON [Fulde navn] TO Jack
GRANT SELECT ON [Fulde navn] TO Pelo

INSERT INTO [Fulde navn]("Navn")
SELECT CONCAT(Fornavn, ' ', Efternavn)
FROM Ansatte

CREATE TABLE Afdelinger(
	"Navn" nvarchar(64) PRIMARY KEY,
	Adresse nvarchar(64),
	Postnummer nvarchar(64)
);
GO

GRANT CONTROL ON Afdelinger TO Jack
GRANT SELECT ON Afdelinger TO Pelo

INSERT INTO Afdelinger("Navn", Adresse, Postnummer)
VALUES
	('Lager', 'S�ndre Mellemvej 19', '4000 Roskilde'),
	('Eventkoordinering', 'Englandsvej 49', '2300 K�benhavn'),
	('Hovedkontor', 'Jordb�rvej 147', '2400 K�benhavn NV')

CREATE TABLE Ansattefordeling(
	"Navn" nvarchar(128) PRIMARY KEY FOREIGN KEY REFERENCES [Fulde navn],
	Afdeling nvarchar(64) FOREIGN KEY REFERENCES Afdelinger(Navn),
	Adresse nvarchar(64),
	Postnummer nvarchar(64)
);
GO

GRANT CONTROL ON Ansattefordeling TO Jack
GRANT SELECT ON Ansattefordeling TO Pelo

INSERT INTO Ansattefordeling
VALUES
	('Asger Brams', 'Eventkoordinering', 'Englandsvej 49', '2300 K�benhavn'),
	('Tatiana Steensen', 'Eventkoordinering', 'Englandsvej 49', '2300 K�benhavn'),
	('Vivian Jokumsen', 'Eventkoordinering', 'Englandsvej 49', '2300 K�benhavn'),
	('Gitte Dalgaard', 'Eventkoordinering', 'Englandsvej 49', '2300 K�benhavn'),
	('Rune Strand', 'Eventkoordinering', 'Englandsvej 49', '2300 K�benhavn'),
	('Christa Bjarnesen', 'Eventkoordinering', 'Englandsvej 49', '2300 K�benhavn'),
	('Marius Str�m', 'Eventkoordinering', 'Englandsvej 49', '2300 K�benhavn'),
	('Birgitte Steensen', 'Eventkoordinering', 'Englandsvej 49', '2300 K�benhavn'),
	('Bernt Jokumsen', 'Lager', 'S�ndre Mellemvej 19', '4000 Roskilde'),
	('Pia Dam', 'Lager', 'S�ndre Mellemvej 19', '4000 Roskilde'),
	('Viktoria Iversen', 'Lager', 'S�ndre Mellemvej 19', '4000 Roskilde'),
	('Karsten Lange', 'Lager', 'S�ndre Mellemvej 19', '4000 Roskilde'),
	('Catrine Steffensen', 'Hovedkontor', 'Jordb�rvej 147', '2400 K�benhavn NV'),
	('Thea Andreassen', 'Hovedkontor', 'Jordb�rvej 147', '2400 K�benhavn NV'),
	('Orla Olson', 'Hovedkontor', 'Jordb�rvej 147', '2400 K�benhavn NV')

--Virker ikke
--CREATE TABLE Projekter(
--	Afdeling nvarchar(64), FOREIGN KEY REFERENCES Afdeling("navn"),
--	"Tilknyttet ansatte" nvarchar(64) FOREIGN KEY REFERENCES Ansatte(Fornavn) not null,
--	Titel nvarchar(64) not null,
--	Beskrivelse nvarchar(300) not null,
--	Startdato date not null,
--	Slutdato date not null,
--	Fremskridt nvarchar(10)
--);
--GO