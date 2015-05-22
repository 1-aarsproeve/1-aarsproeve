/* Opretter database */
CREATE DATABASE [1aarsproeveDB]
GO
USE [1aarsproeveDB]

/* Opretter Stillinger-tabel */
CREATE TABLE [Stillinger] (
    [StillingId] INT          IDENTITY (1, 1) NOT NULL,
    [Stilling]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([StillingId] ASC)
);
/* Indsætter i Stillinger-tabel */
INSERT INTO Stillinger VALUES ('Butikschef');
INSERT INTO Stillinger VALUES ('Ungarbejder');
INSERT INTO Stillinger VALUES ('Nøglebærer');
INSERT INTO Stillinger VALUES ('Flaskedreng');

/* Opretter Ugedage-tabel */
CREATE TABLE [Ugedage] (
    [UgedagId] INT         IDENTITY (1, 1) NOT NULL,
    [Ugedag]   VARCHAR (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([UgedagId] ASC)
);
/* Indsætter i Ugedage-tabel */
INSERT INTO Ugedage VALUES ('Mandag');
INSERT INTO Ugedage VALUES ('Tirsdag');
INSERT INTO Ugedage VALUES ('Onsdag');
INSERT INTO Ugedage VALUES ('Torsdag');
INSERT INTO Ugedage VALUES ('Fredag');
INSERT INTO Ugedage VALUES ('Lørdag');
INSERT INTO Ugedage VALUES ('Søndag');

/* Opretter Ansatte-tabel */
CREATE TABLE [Ansatte] (
    [Brugernavn] VARCHAR (50) NOT NULL,
    [Navn]       VARCHAR (50) NOT NULL,
    [Password]   VARCHAR (50) NOT NULL,
    [Email]      VARCHAR (50) NOT NULL,
    [Mobil]      VARCHAR (50) NOT NULL,
    [Adresse]    VARCHAR (50) NOT NULL,
    [Postnummer] VARCHAR (50) NOT NULL,
    [StillingId] INT          DEFAULT ((2)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Brugernavn] ASC),
    CONSTRAINT [FK_Ansatte_Roller] FOREIGN KEY ([StillingId]) REFERENCES [Stillinger] ([StillingId])
);
/* Indsætter i Ansatte-tabel */
INSERT INTO Ansatte VALUES ('Daniel', 'Daniel Winther', '66d3c1dff5c55c9138f65a213f843d47', 'daniel@hotmail.dk', '88888888', 'Degnestavnen 99', '2400', 1);
INSERT INTO Ansatte VALUES ('Jari', 'Jari Larsen', '66d3c1dff5c55c9138f65a213f843d47', 'jari@hotmail.dk', '88888888', 'Roskildevej 69', '4000', 2);
INSERT INTO Ansatte VALUES ('Jacob', 'Jacob Balling', '66d3c1dff5c55c9138f65a213f843d47', 'jacob@hotmail.dk', '88888888', 'Skelbækvej 79', '3650', 3);
INSERT INTO Ansatte VALUES ('Benjamin', 'Benjamin Jensen', '66d3c1dff5c55c9138f65a213f843d47', 'benjamin@hotmail.dk', '88888888', 'Enghavevej 44', '3500', 4);
INSERT INTO Ansatte VALUES ('Ubemandet', 'Ubemandet', '66d3c1dff5c55c9138f65a213f843d47', 'infol@fakta.dk', '88888888', 'Jyderupvej 27', '2300', 1);

/* Opretter Vagter-tabel */
CREATE TABLE [Vagter] (
    [VagtId]         INT          IDENTITY (1, 1) NOT NULL,
    [Starttidspunkt] TIME (0)     NOT NULL,
    [Sluttidspunkt]  TIME (0)     NOT NULL,
    [Ugenummer]      INT          NOT NULL,
    [UgedagId]       INT          NOT NULL,
    [Brugernavn]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([VagtId] ASC),
    CONSTRAINT [FK_Vagter_Ugedage] FOREIGN KEY ([UgedagId]) REFERENCES [Ugedage] ([UgedagId]),
    CONSTRAINT [FK_Vagter_Ansatte] FOREIGN KEY ([Brugernavn]) REFERENCES [Ansatte] ([Brugernavn])
);
/* Indsætter i Vagter-tabel */
INSERT INTO Vagter VALUES('08:00','15:00',25,'1','Jacob');
INSERT INTO Vagter VALUES('10:00','13:00',26,'1','Ubemandet');
INSERT INTO Vagter VALUES('12:00','13:00',22,'1','Daniel');
INSERT INTO Vagter VALUES('10:00','12:00',22,'1','Ubemandet');
INSERT INTO Vagter VALUES('12:00','12:00',28,'1','Jari');
INSERT INTO Vagter VALUES('09:00','16:00',26,'1','Benjamin');
INSERT INTO Vagter VALUES('10:00','13:00',29,'1','Ubemandet');
INSERT INTO Vagter VALUES('08:00','13:00',30,'2','Benjamin');
INSERT INTO Vagter VALUES('12:00','15:00',22,'2','Ubemandet');
INSERT INTO Vagter VALUES('09:00','16:00',23,'2','Benjamin');
INSERT INTO Vagter VALUES('10:00','14:00',26,'2','Daniel');
INSERT INTO Vagter VALUES('09:00','17:00',20,'2','Ubemandet');
INSERT INTO Vagter VALUES('08:00','17:00',27,'2','Daniel');
INSERT INTO Vagter VALUES('09:00','12:00',25,'4','Ubemandet');
INSERT INTO Vagter VALUES('12:00','14:00',23,'3','Jari');
INSERT INTO Vagter VALUES('07:00','15:00',20,'3','Jacob');
INSERT INTO Vagter VALUES('10:00','15:00',30,'3','Jari');
INSERT INTO Vagter VALUES('12:00','14:00',21,'3','Jari');
INSERT INTO Vagter VALUES('08:00','16:00',25,'3','Jari');
INSERT INTO Vagter VALUES('07:00','13:00',21,'3','Benjamin');
INSERT INTO Vagter VALUES('08:00','17:00',29,'3','Benjamin');
INSERT INTO Vagter VALUES('08:00','12:00',21,'4','Jari');
INSERT INTO Vagter VALUES('09:00','16:00',24,'4','Ubemandet');
INSERT INTO Vagter VALUES('11:00','16:00',23,'4','Jacob');
INSERT INTO Vagter VALUES('11:00','12:00',22,'4','Ubemandet');
INSERT INTO Vagter VALUES('09:00','12:00',26,'4','Daniel');
INSERT INTO Vagter VALUES('11:00','14:00',27,'4','Jari');
INSERT INTO Vagter VALUES('11:00','17:00',23,'4','Daniel');
INSERT INTO Vagter VALUES('09:00','16:00',28,'5','Jari');
INSERT INTO Vagter VALUES('11:00','13:00',21,'5','Jari');
INSERT INTO Vagter VALUES('08:00','15:00',27,'5','Ubemandet');
INSERT INTO Vagter VALUES('11:00','15:00',24,'5','Jacob');
INSERT INTO Vagter VALUES('11:00','14:00',22,'5','Jari');
INSERT INTO Vagter VALUES('08:00','17:00',21,'5','Ubemandet');
INSERT INTO Vagter VALUES('08:00','14:00',29,'5','Ubemandet');
INSERT INTO Vagter VALUES('09:00','15:00',21,'6','Ubemandet');
INSERT INTO Vagter VALUES('11:00','17:00',26,'6','Benjamin');
INSERT INTO Vagter VALUES('09:00','12:00',28,'6','Benjamin');
INSERT INTO Vagter VALUES('10:00','14:00',27,'6','Daniel');
INSERT INTO Vagter VALUES('07:00','16:00',30,'6','Ubemandet');
INSERT INTO Vagter VALUES('11:00','13:00',28,'6','Ubemandet');
INSERT INTO Vagter VALUES('09:00','13:00',27,'6','Benjamin');
INSERT INTO Vagter VALUES('07:00','15:00',21,'7','Jacob');
INSERT INTO Vagter VALUES('12:00','12:00',29,'7','Jari');
INSERT INTO Vagter VALUES('08:00','14:00',25,'7','Daniel');
INSERT INTO Vagter VALUES('10:00','14:00',21,'7','Ubemandet');
INSERT INTO Vagter VALUES('12:00','14:00',20,'7','Benjamin');
INSERT INTO Vagter VALUES('09:00','14:00',25,'7','Ubemandet');
INSERT INTO Vagter VALUES('11:00','16:00',23,'7','Jari');
INSERT INTO Vagter VALUES('09:00','14:00',27,'1','Jacob');
INSERT INTO Vagter VALUES('10:00','17:00',30,'1','Benjamin');
INSERT INTO Vagter VALUES('08:00','16:00',28,'1','Jacob');
INSERT INTO Vagter VALUES('07:00','13:00',23,'1','Jacob');
INSERT INTO Vagter VALUES('07:00','17:00',23,'1','Daniel');
INSERT INTO Vagter VALUES('08:00','16:00',30,'1','Ubemandet');
INSERT INTO Vagter VALUES('09:00','13:00',27,'1','Daniel');
INSERT INTO Vagter VALUES('08:00','14:00',29,'2','Daniel');
INSERT INTO Vagter VALUES('12:00','15:00',25,'4','Benjamin');
INSERT INTO Vagter VALUES('08:00','16:00',25,'2','Jacob');
INSERT INTO Vagter VALUES('07:00','12:00',26,'2','Jacob');
INSERT INTO Vagter VALUES('09:00','12:00',26,'2','Jacob');
INSERT INTO Vagter VALUES('07:00','13:00',20,'2','Ubemandet');
INSERT INTO Vagter VALUES('11:00','16:00',25,'2','Ubemandet');
INSERT INTO Vagter VALUES('12:00','17:00',24,'3','Benjamin');
INSERT INTO Vagter VALUES('07:00','16:00',30,'3','Daniel');
INSERT INTO Vagter VALUES('11:00','12:00',23,'3','Benjamin');
INSERT INTO Vagter VALUES('07:00','15:00',26,'3','Benjamin');
INSERT INTO Vagter VALUES('11:00','13:00',27,'3','Jacob');
INSERT INTO Vagter VALUES('11:00','15:00',26,'3','Jacob');
INSERT INTO Vagter VALUES('09:00','12:00',21,'3','Benjamin');
INSERT INTO Vagter VALUES('12:00','17:00',28,'4','Ubemandet');
INSERT INTO Vagter VALUES('10:00','15:00',26,'4','Ubemandet');
INSERT INTO Vagter VALUES('11:00','13:00',24,'4','Jacob');
INSERT INTO Vagter VALUES('08:00','16:00',24,'4','Jari');
INSERT INTO Vagter VALUES('12:00','14:00',28,'4','Ubemandet');
INSERT INTO Vagter VALUES('12:00','15:00',30,'4','Jari');
INSERT INTO Vagter VALUES('11:00','17:00',27,'4','Jari');
INSERT INTO Vagter VALUES('10:00','15:00',25,'5','Jacob');
INSERT INTO Vagter VALUES('10:00','17:00',24,'5','Jari');
INSERT INTO Vagter VALUES('07:00','12:00',20,'5','Jacob');
INSERT INTO Vagter VALUES('10:00','13:00',22,'5','Daniel');
INSERT INTO Vagter VALUES('11:00','16:00',30,'5','Ubemandet');
INSERT INTO Vagter VALUES('08:00','17:00',24,'5','Jari');
INSERT INTO Vagter VALUES('12:00','13:00',21,'5','Jari');
INSERT INTO Vagter VALUES('12:00','16:00',29,'6','Ubemandet');
INSERT INTO Vagter VALUES('07:00','17:00',27,'6','Ubemandet');
INSERT INTO Vagter VALUES('10:00','12:00',26,'6','Ubemandet');
INSERT INTO Vagter VALUES('10:00','14:00',22,'6','Jari');
INSERT INTO Vagter VALUES('09:00','13:00',25,'6','Ubemandet');
INSERT INTO Vagter VALUES('12:00','16:00',27,'6','Benjamin');
INSERT INTO Vagter VALUES('07:00','17:00',29,'6','Jari');
INSERT INTO Vagter VALUES('10:00','17:00',30,'7','Benjamin');
INSERT INTO Vagter VALUES('09:00','13:00',29,'7','Jari');
INSERT INTO Vagter VALUES('11:00','14:00',28,'7','Benjamin');
INSERT INTO Vagter VALUES('12:00','15:00',20,'7','Daniel');
INSERT INTO Vagter VALUES('09:00','12:00',28,'7','Ubemandet');
INSERT INTO Vagter VALUES('08:00','15:00',28,'7','Benjamin');
INSERT INTO Vagter VALUES('12:00','12:00',22,'7','Benjamin');
INSERT INTO Vagter VALUES('10:00','17:00',24,'1','Benjamin');
INSERT INTO Vagter VALUES('08:00','16:00',22,'1','Daniel');

/* Opretter Beskeder-tabel */
CREATE TABLE [Beskeder] (
    [BeskedId]    INT          IDENTITY (1, 1) NOT NULL,
    [Overskrift]  VARCHAR (50) NOT NULL,
    [Dato]        DATE         NOT NULL,
    [Beskrivelse] TEXT         NOT NULL,
    [Udloebsdato] DATE         NOT NULL,
    [Brugernavn]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([BeskedId] ASC),
    CONSTRAINT [FK_Beskeder_Ansatte] FOREIGN KEY ([Brugernavn]) REFERENCES [Ansatte] ([Brugernavn])
);
/* Indsætter i Besked-tabel */
INSERT INTO Beskeder VALUES ('MUS-samtaler', GETDATE(), 'Så er der MUS-samtaler!', DATEADD(mm, +1, GETDATE()), 'Daniel');

/* Opretter Anmodninger-tabl */
CREATE TABLE [Anmodninger] (
    [AnmodningId]         INT          IDENTITY (1, 1) NOT NULL,
    [VagtId]              INT          NOT NULL,
    [AnmodningBrugernavn] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AnmodningId] ASC),
    CONSTRAINT [FK_Anmodninger_Vagter] FOREIGN KEY ([VagtId]) REFERENCES [Vagter] ([VagtId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Anmodninger_Ansatte] FOREIGN KEY ([AnmodningBrugernavn]) REFERENCES [Ansatte] ([Brugernavn]) ON DELETE CASCADE
);
INSERT INTO Anmodninger VALUES (3,'Benjamin');

GO
/* Opretter HovedmenuView */
CREATE VIEW [HovedmenuView]
	AS SELECT TOP 100 Beskeder.*, Ansatte.Navn FROM [Beskeder] 
	JOIN Ansatte ON Beskeder.Brugernavn = Ansatte.Brugernavn
	WHERE Beskeder.Udloebsdato > GETDATE()
	ORDER BY Beskeder.Dato DESC, Beskeder.BeskedId DESC
GO
/* Opretter VagtplanView */
CREATE VIEW [VagtplanView]
	AS SELECT Vagter.Starttidspunkt, Vagter.Sluttidspunkt, Vagter.UgedagId, Vagter.Ugenummer, Vagter.VagtId, Ansatte.Brugernavn, Ansatte.Navn FROM [Vagter]
	JOIN Ansatte ON Vagter.Brugernavn = Ansatte.Brugernavn
GO
/* Opretter AnmodningerView */ 
CREATE VIEW [AnmodningerView]
	AS SELECT Anmodninger.AnmodningId, Anmodninger.AnmodningBrugernavn, Ansatte.Navn, Vagter.Starttidspunkt, Vagter.Sluttidspunkt, Vagter.UgedagId, Vagter.Ugenummer, Vagter.Brugernavn, Vagter.VagtId, Ugedage.Ugedag FROM [Anmodninger]
	JOIN Vagter ON Anmodninger.VagtId = Vagter.VagtId
	JOIN Ansatte ON Anmodninger.AnmodningBrugernavn = Ansatte.Brugernavn
	JOIN Ugedage On Vagter.UgedagId = Ugedage.UgedagId
GO