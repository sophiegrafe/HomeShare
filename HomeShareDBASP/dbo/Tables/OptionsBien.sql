CREATE TABLE [dbo].[OptionsBien] (
    [IdOption] INT           NOT NULL,
    [IdBien]   INT           NOT NULL,
    [Valeur]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OptionsBien] PRIMARY KEY CLUSTERED ([IdOption] ASC, [IdBien] ASC),
    CONSTRAINT [FK_OptionsBien_BienEchange] FOREIGN KEY ([IdBien]) REFERENCES [dbo].[BienEchange] ([IdBien]),
    CONSTRAINT [FK_OptionsBien_Options] FOREIGN KEY ([IdOption]) REFERENCES [dbo].[Options] ([IdOption])
);

