USE ITIN20LAP;
GO

INSERT INTO Einrichtungen(Beschreibung) VALUES('Stuhl');
INSERT INTO Einrichtungen(Beschreibung) VALUES('Tisch');
INSERT INTO Einrichtungen(Beschreibung) VALUES('Monitor');
INSERT INTO Einrichtungen(Beschreibung) VALUES('Computer');
INSERT INTO Einrichtungen(Beschreibung) VALUES('Kasten');
GO

INSERT INTO Gebäude(FirmenName,Plz,Stadt,Straße,Hausnummer,[order],active) VALUES('crowd-o-moto','1110','Wien','Volkstheater','17',1,'True');
INSERT INTO Gebäude(FirmenName,Plz,Stadt,Straße,Hausnummer,[order],active) VALUES('pc-web','4020','Linz','Wienerstrasse','22',2,'True');
INSERT INTO Gebäude(FirmenName,Plz,Stadt,Straße,Hausnummer,[order],active) VALUES('bundesrechenzentrum','5020','Salzburg','Hinterholz','8',3,'True');
INSERT INTO Gebäude(FirmenName,Plz,Stadt,Straße,Hausnummer,[order],active) VALUES('bbrz-Vorarlberg','6700','Bregenz','Mariahilfsstrasse','2',4,'True');
INSERT INTO Gebäude(FirmenName,Plz,Stadt,Straße,Hausnummer,[order],active) VALUES('bbrz-Schärding','4975','Schärding','Linzerstrasse','1',5,'True');
Go

INSERT INTO Räume(Gebäude_Id,Beschreibung) VALUES(1,'EntwicklerBüro');
INSERT INTO Räume(Gebäude_Id,Beschreibung) VALUES(2,'ServerRaum');
INSERT INTO Räume(Gebäude_Id,Beschreibung) VALUES(3,'TechnikerBüro');
INSERT INTO Räume(Gebäude_Id,Beschreibung) VALUES(4,'LagerRaum');
INSERT INTO Räume(Gebäude_Id,Beschreibung) VALUES(5,'Büro');
GO

--1 RaumEinrichtungen id 1-5 per 5 Räume
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(1,1);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(1,2);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(1,3);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(1,4);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(1,5);
--2
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(2,1);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(2,2);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(2,3);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(2,4);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(2,5);
--3
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(3,1);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(3,2);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(3,3);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(3,4);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(3,5);
--4
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(4,1);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(4,2);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(4,3);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(4,4);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(4,5);
--5
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(5,1);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(5,2);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(5,3);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(5,4);
INSERT INTO RaumEinrichtungen(Raum_Id,Einrichtung_Id) VALUES(5,5);
GO

INSERT INTO BenutzerRollen(Beschreibung,active) VALUES('Admin', 'true');
INSERT INTO BenutzerRollen(Beschreibung,active) VALUES('User', 'true');
INSERT INTO BenutzerRollen(Beschreibung,active) VALUES('Mitarbeiter', 'false');
GO

INSERT INTO Firmen(FirmenName,Plz,Stadt,Straße,Hausnummer) VALUES('Microsoft','1120','Wien','Am Europl.','3');
INSERT INTO Firmen(FirmenName,Plz,Stadt,Straße,Hausnummer) VALUES('Apple','1110','Wien','Westbahnhof','22');
INSERT INTO Firmen(FirmenName,Plz,Stadt,Straße,Hausnummer) VALUES('Blizzard','1311','Wien','Stephansplatz','11');
INSERT INTO Firmen(FirmenName,Plz,Stadt,Straße,Hausnummer) VALUES('Westwood','1140','Wien','Rennbahnweg','2');
INSERT INTO Firmen(FirmenName,Plz,Stadt,Straße,Hausnummer) VALUES('Notch','1340','Wien','Rennbahnweg','13');
GO

INSERT INTO Benutzer(BenutzerRolle_Id,Firmen_Id,email,Passwort,Vorname,Nachname,ist_Mitarbeiter, active) VALUES(2,1,'dzallinger@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Daniel','Zallinger','true', 'true');
INSERT INTO Benutzer(BenutzerRolle_Id,Firmen_Id,email,Passwort,Vorname,Nachname,ist_Mitarbeiter, active) VALUES(1,2,'mbichler@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Max','Bichler','false', 'true');
INSERT INTO Benutzer(BenutzerRolle_Id,Firmen_Id,email,Passwort,Vorname,Nachname,ist_Mitarbeiter, active) VALUES(2,3,'edruckner@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Erwin','Druckner','false', 'false');
INSERT INTO Benutzer(BenutzerRolle_Id,Firmen_Id,email,Passwort,Vorname,Nachname,ist_Mitarbeiter, active) VALUES(3,4,'pwagner@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Phillip','Wagner','false', 'false');
INSERT INTO Benutzer(BenutzerRolle_Id,Firmen_Id,email,Passwort,Vorname,Nachname,ist_Mitarbeiter, active) VALUES(3,5,'bmarkovic@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Bojan','Markovic','false', 'false');
GO

INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(1,1,'2016-01-09');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(2,2,'2016-13-06');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(3,3,'2016-20-06');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(4,4,'2017-01-01');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(5,5,'2017-13-01');
GO

--last Month Bookings
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(1,1,'2017-20-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(4,1,'2017-23-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(3,1,'2017-27-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(2,2,'2017-12-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(1,2,'2017-13-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(5,2,'2017-11-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(1,3,'2017-10-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(2,3,'2017-13-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(5,3,'2017-20-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(4,4,'2017-12-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(1,4,'2017-08-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(2,4,'2017-09-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(5,5,'2017-07-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(3,5,'2017-15-02');
INSERT INTO Buchungen(Raum_Id,Benutzer_Id,Datum) VALUES(4,5,'2017-19-02');
GO


INSERT INTO Rechnungen(Datum,Benutzer_Id) VALUES('2016-08-09',1);
INSERT INTO Rechnungen(Datum,Benutzer_Id) VALUES('2016-20-06',1);
INSERT INTO Rechnungen(Datum,Benutzer_Id) VALUES('2016-27-06',1);
INSERT INTO Rechnungen(Datum,Benutzer_Id) VALUES('2017-08-01',1);
INSERT INTO Rechnungen(Datum,Benutzer_Id) VALUES('2017-20-01',1);
Go

INSERT INTO RechnungsDetails(Rechnung_Id,Datum,Buchung_Id) VALUES(1,'2016-08-01',1);
INSERT INTO RechnungsDetails(Rechnung_Id,Datum,Buchung_Id) VALUES(2,'2016-20-06',2);
INSERT INTO RechnungsDetails(Rechnung_Id,Datum,Buchung_Id) VALUES(3,'2016-27-06',3);
INSERT INTO RechnungsDetails(Rechnung_Id,Datum,Buchung_Id) VALUES(4,'2017-08-01',4);
INSERT INTO RechnungsDetails(Rechnung_Id,Datum,Buchung_Id) VALUES(5,'2017-20-01',5);
GO

INSERT INTO Kontakte(Benutzer_Id,Firmen_Id) VALUES(1,1);
INSERT INTO Kontakte(Benutzer_Id,Firmen_Id) VALUES(2,2);
INSERT INTO Kontakte(Benutzer_Id,Firmen_Id) VALUES(3,3);
INSERT INTO Kontakte(Benutzer_Id,Firmen_Id) VALUES(4,4);
INSERT INTO Kontakte(Benutzer_Id,Firmen_Id) VALUES(5,5);
GO

INSERT INTO Stornierungen(Buchung_Id,Benutzer_Id,Grund) VALUES(1,1,'Langweilig');
INSERT INTO Stornierungen(Buchung_Id,Benutzer_Id,Grund) VALUES(2,2,'Nicht Gut');
INSERT INTO Stornierungen(Buchung_Id,Benutzer_Id,Grund) VALUES(3,3,'Nicht Schön');
INSERT INTO Stornierungen(Buchung_Id,Benutzer_Id,Grund) VALUES(4,4,'Raum zu Gros');
INSERT INTO Stornierungen(Buchung_Id,Benutzer_Id,Grund) VALUES(5,5,'raum zu klein');
GO
