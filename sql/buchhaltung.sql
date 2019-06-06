CREATE DATABASE Buchhaltung;
GO;

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

GO;

INSERT INTO KontoArt ('Umlauf Vermögen', 'UL');
INSERT INTO KontoArt ('Anlage Vermögen', 'AL');
INSERT INTO KontoArt ('Fremdkapital', 'FK');
INSERT INTO KontoArt ('Eigenkapital', 'EK');

INSERT INTO Konto ('Kasse', 'KA', 1, 1);
INSERT INTO Konto ('Bank', 'BA', 2, 1);
INSERT INTO Konto ('Post', 'PO', 3, 1);
INSERT INTO Konto ('Forderungen LL', 'FLL', 4, 1);

INSERT INTO Konto ('Warenbestand', 'WaB', 1, 2);
INSERT INTO Konto ('Mobilien', 'MO', 2, 2);
INSERT INTO Konto ('Immobilien', 'IM', 3, 2);

INSERT INTO Konto ('Verbindlichkeiten LL', 'VLL', 1, 3);
INSERT INTO Konto ('Darlehensschuld', 'DS', 2, 3);
INSERT INTO Konto ('Hypothek', 'HY', 3, 3);

INSERT INTO Konto ('Eigenkapital', 'EIK', 1, 4);

INSERT INTO Bilanz ('Bilanz BBZW Sursee', 'BBZW2019', GETDATE());
