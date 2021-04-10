CREATE TABLE [dbo].[Options] (
    [IdOption] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED ([IdOption] ASC)
);

