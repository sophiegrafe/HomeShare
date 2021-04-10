CREATE TABLE [dbo].[AvisMembreBien] (
    [IdAvis]   INT      IDENTITY (1, 1) NOT NULL,
    [Note]     INT      NOT NULL,
    [Message]  NTEXT    NOT NULL,
    [IdMembre] INT      NOT NULL,
    [IdBien]   INT      NOT NULL,
    [DateAvis] DATETIME NOT NULL,
    [Approuve] BIT      CONSTRAINT [DF_AvisMembreBien_Approuve] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AvisMembreBien] PRIMARY KEY CLUSTERED ([IdAvis] ASC),
    CONSTRAINT [FK_AvisMembreBien_BienEchange] FOREIGN KEY ([IdBien]) REFERENCES [dbo].[BienEchange] ([IdBien]),
    CONSTRAINT [FK_AvisMembreBien_membre] FOREIGN KEY ([IdMembre]) REFERENCES [dbo].[Membre] ([IdMembre])
);

