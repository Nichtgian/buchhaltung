CREATE DATABASE Buchhaltung;
GO

USE Buchhaltung;
GO

CREATE TABLE Bilanz (
  Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Bezeichnung VARCHAR(30) NOT NULL,
	Code VARCHAR(10) NOT NULL UNIQUE,
  Datum DATETIME NOT NULL
);

CREATE TABLE KontoArt (
  Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Bezeichnung VARCHAR(30) NOT NULL,
	Code VARCHAR(10) NOT NULL UNIQUE,
  IsPositive BIT
);

CREATE TABLE Konto (
  Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Bezeichnung VARCHAR(30) NOT NULL,
	Code VARCHAR(10) NOT NULL UNIQUE,
  Reihenfolge INT NOT NULL,
  KontoArt INT NOT NULL,
  FOREIGN KEY (KontoArt) REFERENCES KontoArt(Id)
);

CREATE TABLE Buchungssatz (
  Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Soll INT NOT NULL,
  Haben INT NOT NULL,
  Betrag FLOAT NOT NULL,
  Beschreibung VARCHAR(250),
  Bilanz INT NOT NULL,
  FOREIGN KEY (Soll) REFERENCES Konto(Id),
  FOREIGN KEY (Haben) REFERENCES Konto(Id),
  FOREIGN KEY (Bilanz) REFERENCES Bilanz(Id)
);

CREATE TABLE Anfangsbetrag (
  Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Konto INT NOT NULL,
  Betrag FLOAT NOT NULL,
  Bilanz INT NOT NULL,
  FOREIGN KEY (Konto) REFERENCES Konto(Id),
  FOREIGN KEY (Bilanz) REFERENCES Bilanz(Id),
);

GO

INSERT INTO KontoArt VALUES ('Umlauf Vermögen', 'ULAK', 1); /*AK = AktivKonto*/
INSERT INTO KontoArt VALUES ('Anlage Vermögen', 'ALAK', 1);
INSERT INTO KontoArt VALUES ('Fremdkapital', 'FKPK', 0); /*PK = PassivKonto*/
INSERT INTO KontoArt VALUES ('Eigenkapital', 'EKPK', 0);
INSERT INTO KontoArt VALUES ('Aufwand', 'AEK', 1); /*EK = ErfolgsKonto*/
INSERT INTO KontoArt VALUES ('Ertrag', 'EEK', 0);

INSERT INTO Konto VALUES ('Kasse', 'KAE', 1, 1);
INSERT INTO Konto VALUES ('Bank', 'BAK', 2, 1);
INSERT INTO Konto VALUES ('Post', 'POT', 3, 1);
INSERT INTO Konto VALUES ('Forderungen LL', 'FLL', 4, 1);

INSERT INTO Konto VALUES ('Warenbestand', 'WAB', 1, 2);
INSERT INTO Konto VALUES ('Mobilien', 'MON', 2, 2);
INSERT INTO Konto VALUES ('Immobilien', 'IMN', 3, 2);

INSERT INTO Konto VALUES ('Verbindlichkeiten LL', 'VLL', 1, 3);
INSERT INTO Konto VALUES ('Darlehensschuld', 'DAS', 2, 3);
INSERT INTO Konto VALUES ('Hypothek', 'HYK', 3, 3);

INSERT INTO Konto VALUES ('Eigenkapital', 'EIK', 1, 4);

INSERT INTO Bilanz VALUES ('Bilanz BBZW Sursee', 'BBZW2019', GETDATE());
INSERT INTO Anfangsbetrag VALUES (1, 500, 1); /*Kasse*/
INSERT INTO Anfangsbetrag VALUES (1, 20000, 11); /*EK*/
INSERT INTO Buchungssatz VALUES (1, 2, 100, 'Kasse / Bank 100', 1);
INSERT INTO Buchungssatz VALUES (6, 1, 100, 'Mobilien / Kasse 100', 1);
