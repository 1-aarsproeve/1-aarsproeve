/* Opretter Stillinger-tabel */
CREATE TABLE [dbo].[Stillinger] (
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
CREATE TABLE [dbo].[Ugedage] (
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
CREATE TABLE [dbo].[Ansatte] (
    [Brugernavn] VARCHAR (50) NOT NULL,
    [Navn]       VARCHAR (50) NOT NULL,
    [Password]   VARCHAR (50) NOT NULL,
    [Email]      VARCHAR (50) NOT NULL,
    [Mobil]      VARCHAR (50) NOT NULL,
    [Adresse]    VARCHAR (50) NOT NULL,
    [Postnummer] VARCHAR (50) NOT NULL,
    [StillingId] INT          DEFAULT ((2)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Brugernavn] ASC),
    CONSTRAINT [FK_Ansatte_Roller] FOREIGN KEY ([StillingId]) REFERENCES [dbo].[Stillinger] ([StillingId])
);
/* Indsætter i Ansatte-tabel */
INSERT INTO Ansatte VALUES ('Daniel', 'Daniel Winther', '123456', 'daniel@hotmail.dk', '88888888', 'Degnestavnen 99', '2400', 1);
INSERT INTO Ansatte VALUES ('Jari', 'Jari Larsen', '123456', 'jari@hotmail.dk', '88888888', 'Roskildevej 69', '4000', 2);
INSERT INTO Ansatte VALUES ('Jacob', 'Jacob Balling', '123456', 'jacob@hotmail.dk', '88888888', 'Skelbækvej 79', '3650', 3);
INSERT INTO Ansatte VALUES ('Benjamin', 'Benjamin Jensen', '123456', 'benjamin@hotmail.dk', '88888888', 'Enghavevej 44', '3500', 4);
INSERT INTO Ansatte VALUES ('Ubemandet', 'Ubemandet', '123456', 'infol@fakta.dk', '88888888', 'Jyderupvej 27', '2400', 1);

/* Opretter Vagter-tabel */
CREATE TABLE [dbo].[Vagter] (
    [VagtId]         INT          IDENTITY (1, 1) NOT NULL,
    [Starttidspunkt] TIME (0)     NOT NULL,
    [Sluttidspunkt]  TIME (0)     NOT NULL,
    [Ugenummer]      INT          NOT NULL,
    [UgedagId]       INT          NOT NULL,
    [Brugernavn]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([VagtId] ASC),
    CONSTRAINT [FK_Vagter_Ugedage] FOREIGN KEY ([UgedagId]) REFERENCES [dbo].[Ugedage] ([UgedagId]),
    CONSTRAINT [FK_Vagter_Ansatte] FOREIGN KEY ([Brugernavn]) REFERENCES [dbo].[Ansatte] ([Brugernavn])
);
/* Indsætter i Vagter-tabel */
INSERT INTO Vagter VALUES ('10:00', '16:00', 20, 1, 'Daniel');
INSERT INTO Vagter VALUES ('08:00', '12:00', 20, 3, 'Ubemandet');
INSERT INTO Vagter VALUES ('16:00', '21:00', 20, 2, 'Benjamin');
INSERT INTO Vagter VALUES ('07:00', '15:00', 20, 4, 'Jacob');
INSERT INTO Vagter VALUES ('07:00', '23:00', 20, 6, 'Jari');

/* Opretter Beskeder-tabel */
CREATE TABLE [dbo].[Beskeder] (
    [BeskedId]    INT          IDENTITY (1, 1) NOT NULL,
    [Overskrift]  VARCHAR (50) NOT NULL,
    [Dato]        DATE         NOT NULL,
    [Beskrivelse] TEXT         NOT NULL,
    [Udloebsdato] DATE         NOT NULL,
    [Brugernavn]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([BeskedId] ASC),
    CONSTRAINT [FK_Beskeder_Ansatte] FOREIGN KEY ([Brugernavn]) REFERENCES [dbo].[Ansatte] ([Brugernavn])
);
/* Indsætter i Besked-tabel */
INSERT INTO Beskeder VALUES ('MUS-samtaler', '2015-04-04', 'Så er der MUS-samtaler!', '2015-05-15', 'Daniel');

/* Opretter Anmodninger-tabl */
CREATE TABLE [dbo].[Anmodninger] (
    [AnmodningId]         INT          IDENTITY (1, 1) NOT NULL,
    [VagtId]              INT          NOT NULL,
    [AnmodningBrugernavn] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AnmodningId] ASC),
    CONSTRAINT [FK_Anmodninger_Vagter] FOREIGN KEY ([VagtId]) REFERENCES [dbo].[Vagter] ([VagtId]),
    CONSTRAINT [FK_Anmodninger_Ansatte] FOREIGN KEY ([AnmodningBrugernavn]) REFERENCES [dbo].[Ansatte] ([Brugernavn])
);
INSERT INTO Anmodninger VALUES (3,'Daniel');

/* Opretter HovedmenuView */
GO
CREATE VIEW [dbo].[HovedmenuView]
	AS  SELECT Beskeder.*, Ansatte.Navn FROM [Beskeder] 
	JOIN Ansatte ON Beskeder.Brugernavn = Ansatte.Brugernavn
	WHERE Beskeder.Udloebsdato > GETDATE()
/* Opretter VagtplanView */
GO
CREATE VIEW [dbo].[VagtplanView]
	AS SELECT Vagter.Starttidspunkt, Vagter.Sluttidspunkt, Vagter.UgedagId, Vagter.Ugenummer, Vagter.VagtId, Ansatte.Brugernavn, Ansatte.Navn FROM [Vagter]
	JOIN Ansatte ON Vagter.Brugernavn = Ansatte.Brugernavn
/* Opretter AnmodningerView */ 
GO
CREATE VIEW [dbo].[AnmodningerView]
	AS SELECT Anmodninger.AnmodningId, Anmodninger.AnmodningBrugernavn, Vagter.Starttidspunkt, Vagter.Sluttidspunkt, Vagter.UgedagId, Vagter.Ugenummer, Vagter.Brugernavn, Vagter.VagtId, Ugedage.Ugedag FROM [Anmodninger]
	JOIN Vagter ON Anmodninger.VagtId = Vagter.VagtId
	JOIN Ugedage On Vagter.UgedagId = Ugedage.UgedagId
GO