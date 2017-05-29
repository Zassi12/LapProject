USE  ITIN20LAP
GO

ALTER TABLE Einrichtungen
ADD
CONSTRAINT pk_Einrichtungen
PRIMARY KEY (Id)
GO
 

ALTER TABLE RaumEinrichtungen 
ADD
CONSTRAINT pk_RaumEinrichtungen
PRIMARY KEY (Id)
GO
 

ALTER TABLE R�ume 
ADD
CONSTRAINT pk_R�ume
PRIMARY KEY (Id)
GO
 

ALTER TABLE Geb�ude 
ADD
CONSTRAINT pk_Geb�ude
PRIMARY KEY (Id)
GO
 

ALTER TABLE Buchungen 
ADD
CONSTRAINT pk_Buchungen
PRIMARY KEY (Id)
GO
 

ALTER TABLE RechnungsDetails 
ADD
CONSTRAINT pk_RechnungsDetails
PRIMARY KEY (Id)
GO
 

ALTER TABLE Rechnungen 
ADD
CONSTRAINT pk_Rechnungen
PRIMARY KEY (Id)
GO

ALTER TABLE Benutzer 
ADD
CONSTRAINT pk_Benutzer
PRIMARY KEY (Id)
GO
 

ALTER TABLE BenutzerRollen 
ADD
CONSTRAINT pk_BenutzerRollen
PRIMARY KEY (Id)
GO
 

ALTER TABLE Kontakte 
ADD
CONSTRAINT pk_Kontakte
PRIMARY KEY (Id)
GO

ALTER TABLE Firmen 
ADD
CONSTRAINT pk_Firmen
PRIMARY KEY (Id)
GO

ALTER TABLE Stornierungen 
ADD
CONSTRAINT pk_Stornierungen
PRIMARY KEY (Id)
GO
 
ALTER TABLE [Log] 
ADD
CONSTRAINT pk_Log
PRIMARY KEY (Id)
GO