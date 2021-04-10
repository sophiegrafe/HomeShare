CREATE TABLE [dbo].[Membre] (
    [IdMembre]  INT            IDENTITY (1, 1) NOT NULL,
    [Nom]       NVARCHAR (50)  NOT NULL,
    [Prenom]    NVARCHAR (50)  NOT NULL,
    [Email]     NVARCHAR (256) NOT NULL,
    [Pays]      INT            NOT NULL,
    [Telephone] NVARCHAR (20)  NOT NULL,
    [Login]     NVARCHAR (64)  NOT NULL,
    [Password]  NVARCHAR (1024) NOT NULL,
    [Salt] CHAR(8) NULL, 
    CONSTRAINT [PK_membre] PRIMARY KEY CLUSTERED ([IdMembre] ASC)
);

