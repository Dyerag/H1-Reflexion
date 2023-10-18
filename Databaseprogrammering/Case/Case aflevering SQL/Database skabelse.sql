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
	Fødselsdag DATE not null,
	"Månedsløn i kr." int not null,
	Ansættelsesdato date not null
);
GO

GRANT CONTROL ON Ansatte TO Jack
GRANT SELECT ON Ansatte TO Pelo

--Alt data laves af rng sider:
-- name = https://www.behindthename.com/random/
-- salary = den der dukker op på google når man søger på en rng generator. variationen er: 7000 - 35185
-- employementdate = https://www.random.org/calendar-dates/
INSERT INTO Ansatte(Fornavn, Efternavn, Fødselsdag, [Månedsløn i kr.], Ansættelsesdato)
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
	('Marius', 'Strøm', '2005/1/2', 7000, '2022/06/15'),
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
	('Lager', 'Søndre Mellemvej 19', '4000 Roskilde'),
	('Eventkoordinering', 'Englandsvej 49', '2300 København'),
	('Hovedkontor', 'Jordbærvej 147', '2400 København NV')

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
	('Asger Brams', 'Eventkoordinering', 'Englandsvej 49', '2300 København'),
	('Tatiana Steensen', 'Eventkoordinering', 'Englandsvej 49', '2300 København'),
	('Vivian Jokumsen', 'Eventkoordinering', 'Englandsvej 49', '2300 København'),
	('Gitte Dalgaard', 'Eventkoordinering', 'Englandsvej 49', '2300 København'),
	('Rune Strand', 'Eventkoordinering', 'Englandsvej 49', '2300 København'),
	('Christa Bjarnesen', 'Eventkoordinering', 'Englandsvej 49', '2300 København'),
	('Marius Strøm', 'Eventkoordinering', 'Englandsvej 49', '2300 København'),
	('Birgitte Steensen', 'Eventkoordinering', 'Englandsvej 49', '2300 København'),
	('Bernt Jokumsen', 'Lager', 'Søndre Mellemvej 19', '4000 Roskilde'),
	('Pia Dam', 'Lager', 'Søndre Mellemvej 19', '4000 Roskilde'),
	('Viktoria Iversen', 'Lager', 'Søndre Mellemvej 19', '4000 Roskilde'),
	('Karsten Lange', 'Lager', 'Søndre Mellemvej 19', '4000 Roskilde'),
	('Catrine Steffensen', 'Hovedkontor', 'Jordbærvej 147', '2400 København NV'),
	('Thea Andreassen', 'Hovedkontor', 'Jordbærvej 147', '2400 København NV'),
	('Orla Olson', 'Hovedkontor', 'Jordbærvej 147', '2400 København NV')

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