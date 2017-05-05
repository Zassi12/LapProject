USE  ITIN20LAP
GO

ALTER TABLE RaumEinrichtungen 
ADD
CONSTRAINT fk_RaumEinrichtungen_Räume
FOREIGN KEY (Raum_Id)
REFERENCES Räume(Id)
GO
 

ALTER TABLE RaumEinrichtungen 
ADD
CONSTRAINT fk_RaumEinrichtungen_Einrichtungen
FOREIGN KEY (Einrichtung_Id)
REFERENCES Einrichtungen(Id)
GO


ALTER TABLE Räume 
ADD
CONSTRAINT fk_Räume_Gebäude
FOREIGN KEY (Gebäude_Id)
REFERENCES Gebäude(Id)
GO

 

ALTER TABLE Buchungen 
ADD
CONSTRAINT fk_Buchungen_Räume
FOREIGN KEY (Raum_Id)
REFERENCES Räume(Id)
GO
 

ALTER TABLE Buchungen 
ADD
CONSTRAINT fk_Buchungen_Benutzer
FOREIGN KEY (Benutzer_Id)
REFERENCES Benutzer(Id)
GO
 

ALTER TABLE Stornierungen 
ADD
CONSTRAINT fk_Stornierungen_Buchungen
FOREIGN KEY (Buchung_Id)
REFERENCES Buchungen(Id)
GO

ALTER TABLE Stornierungen 
ADD
CONSTRAINT fk_Stornierungen_Benutzer
FOREIGN KEY (Benutzer_Id)
REFERENCES Benutzer(Id)
GO
 

ALTER TABLE Benutzer 
ADD
CONSTRAINT fk_Benutzer_BenutzerRollen
FOREIGN KEY (BenutzerRolle_Id)
REFERENCES BenutzerRollen(Id)
GO

ALTER TABLE Benutzer 
ADD
CONSTRAINT fk_Benutzer_Firmen
FOREIGN KEY (Firmen_Id)
REFERENCES Firmen(Id)
GO
 

ALTER TABLE Kontakte 
ADD
CONSTRAINT fk_Kontakte_Benutzer
FOREIGN KEY (Benutzer_Id)
REFERENCES Benutzer(Id)
GO

ALTER TABLE Kontakte 
ADD
CONSTRAINT fk_Kontakte_Firmen
FOREIGN KEY (Firmen_Id)
REFERENCES Firmen(Id)
GO

ALTER TABLE RechnungsDetails 
ADD
CONSTRAINT fk_RechnungsDetails_Rechnungen
FOREIGN KEY (Rechnung_Id)
REFERENCES Rechnungen(Id)
GO

ALTER TABLE RechnungsDetails 
ADD
CONSTRAINT fk_RechnungsDetails_Buchungen
FOREIGN KEY (Buchung_Id)
REFERENCES Buchungen(Id)
GO

ALTER TABLE Rechnungen 
ADD
CONSTRAINT fk_Rechnungen_Benutzer
FOREIGN KEY (Benutzer_Id)
REFERENCES Benutzer(Id)