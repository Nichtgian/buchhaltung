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
	Code VARCHAR(10) NOT NULL UNIQUE
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
  Bilanz INT,
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

INSERT INTO KontoArt VALUES ('Umlauf Vermögen', 'UL');
INSERT INTO KontoArt VALUES ('Anlage Vermögen', 'AL');
INSERT INTO KontoArt VALUES ('Fremdkapital', 'FK');
INSERT INTO KontoArt VALUES ('Eigenkapital', 'EK');

INSERT INTO Konto VALUES ('Kasse', 'KA', 1, 1);
INSERT INTO Konto VALUES ('Bank', 'BA', 2, 1);
INSERT INTO Konto VALUES ('Post', 'PO', 3, 1);
INSERT INTO Konto VALUES ('Forderungen LL', 'FLL', 4, 1);

INSERT INTO Konto VALUES ('Warenbestand', 'WaB', 1, 2);
INSERT INTO Konto VALUES ('Mobilien', 'MO', 2, 2);
INSERT INTO Konto VALUES ('Immobilien', 'IM', 3, 2);

INSERT INTO Konto VALUES ('Verbindlichkeiten LL', 'VLL', 1, 3);
INSERT INTO Konto VALUES ('Darlehensschuld', 'DS', 2, 3);
INSERT INTO Konto VALUES ('Hypothek', 'HY', 3, 3);

INSERT INTO Konto VALUES ('Eigenkapital', 'EIK', 1, 4);

INSERT INTO Bilanz VALUES ('Bilanz BBZW Sursee', 'BBZW2019', GETDATE());
