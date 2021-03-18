/*
Script de déploiement pour HomeShare.DB

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "HomeShare.DB"
:setvar DefaultFilePrefix "HomeShare.DB"
:setvar DefaultDataPath "C:\Users\Sophie\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Sophie\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de [dbo].[AvisMembreBien]...';


GO
CREATE TABLE [dbo].[AvisMembreBien] (
    [idAvis]   INT      IDENTITY (1, 1) NOT NULL,
    [note]     INT      NOT NULL,
    [message]  NTEXT    NOT NULL,
    [idMembre] INT      NOT NULL,
    [idBien]   INT      NOT NULL,
    [DateAvis] DATETIME NOT NULL,
    [Approuve] BIT      NOT NULL,
    CONSTRAINT [PK_AvisMembreBien] PRIMARY KEY CLUSTERED ([idAvis] ASC) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];


GO
PRINT N'Création de [dbo].[BienEchange]...';


GO
CREATE TABLE [dbo].[BienEchange] (
    [idBien]               INT            IDENTITY (1, 1) NOT NULL,
    [titre]                NVARCHAR (50)  NOT NULL,
    [DescCourte]           NVARCHAR (150) NOT NULL,
    [DescLong]             NTEXT          NOT NULL,
    [NombrePerson]         INT            NOT NULL,
    [Pays]                 INT            NOT NULL,
    [Ville]                NVARCHAR (50)  NOT NULL,
    [Rue]                  NVARCHAR (50)  NOT NULL,
    [Numero]               NVARCHAR (5)   NOT NULL,
    [CodePostal]           NVARCHAR (50)  NOT NULL,
    [Photo]                NVARCHAR (50)  NOT NULL,
    [AssuranceObligatoire] BIT            NOT NULL,
    [isEnabled]            BIT            NOT NULL,
    [DisabledDate]         DATE           NULL,
    [Latitude]             NVARCHAR (50)  NOT NULL,
    [Longitude]            NVARCHAR (50)  NOT NULL,
    [idMembre]             INT            NOT NULL,
    [DateCreation]         DATE           NOT NULL,
    CONSTRAINT [PK_BienEchange] PRIMARY KEY CLUSTERED ([idBien] ASC) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];


GO
PRINT N'Création de [dbo].[Membre]...';


GO
CREATE TABLE [dbo].[Membre] (
    [idMembre]  INT            IDENTITY (1, 1) NOT NULL,
    [Nom]       NVARCHAR (50)  NOT NULL,
    [Prenom]    NVARCHAR (50)  NOT NULL,
    [Email]     NVARCHAR (256) NOT NULL,
    [Pays]      INT            NOT NULL,
    [Telephone] NVARCHAR (20)  NOT NULL,
    [Login]     NVARCHAR (50)  NOT NULL,
    [Password]  NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_membre] PRIMARY KEY CLUSTERED ([idMembre] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Création de [dbo].[MembreBienEchange]...';


GO
CREATE TABLE [dbo].[MembreBienEchange] (
    [idMembre]       INT  NOT NULL,
    [idBien]         INT  NOT NULL,
    [DateDebEchange] DATE NOT NULL,
    [DateFinEchange] DATE NOT NULL,
    [Assurance]      BIT  NULL,
    [Valide]         BIT  NOT NULL,
    CONSTRAINT [PK_MembreBienEchange] PRIMARY KEY CLUSTERED ([idMembre] ASC, [idBien] ASC, [DateDebEchange] ASC, [DateFinEchange] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Création de [dbo].[Options]...';


GO
CREATE TABLE [dbo].[Options] (
    [idOption] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED ([idOption] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Création de [dbo].[OptionsBien]...';


GO
CREATE TABLE [dbo].[OptionsBien] (
    [idOption] INT           NOT NULL,
    [idBien]   INT           NOT NULL,
    [Valeur]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OptionsBien] PRIMARY KEY CLUSTERED ([idOption] ASC, [idBien] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Création de [dbo].[Pays]...';


GO
CREATE TABLE [dbo].[Pays] (
    [idPays]  INT           IDENTITY (1, 1) NOT NULL,
    [Libelle] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Pays] PRIMARY KEY CLUSTERED ([idPays] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Création de [dbo].[DF_AvisMembreBien_Approuve]...';


GO
ALTER TABLE [dbo].[AvisMembreBien]
    ADD CONSTRAINT [DF_AvisMembreBien_Approuve] DEFAULT ((0)) FOR [Approuve];


GO
PRINT N'Création de [dbo].[DF_BienEchange_Pays]...';


GO
ALTER TABLE [dbo].[BienEchange]
    ADD CONSTRAINT [DF_BienEchange_Pays] DEFAULT ((1)) FOR [Pays];


GO
PRINT N'Création de [dbo].[DF_BienEchange_AssuranceObligatoire]...';


GO
ALTER TABLE [dbo].[BienEchange]
    ADD CONSTRAINT [DF_BienEchange_AssuranceObligatoire] DEFAULT ((0)) FOR [AssuranceObligatoire];


GO
PRINT N'Création de [dbo].[DF_BienEchange_isEnabled]...';


GO
ALTER TABLE [dbo].[BienEchange]
    ADD CONSTRAINT [DF_BienEchange_isEnabled] DEFAULT ((0)) FOR [isEnabled];


GO
PRINT N'Création de [dbo].[DF_BienEchange_DateCreation]...';


GO
ALTER TABLE [dbo].[BienEchange]
    ADD CONSTRAINT [DF_BienEchange_DateCreation] DEFAULT (getdate()) FOR [DateCreation];


GO
PRINT N'Création de [dbo].[DF_MembreBienEchange_Valide]...';


GO
ALTER TABLE [dbo].[MembreBienEchange]
    ADD CONSTRAINT [DF_MembreBienEchange_Valide] DEFAULT ((0)) FOR [Valide];


GO
PRINT N'Création de [dbo].[FK_AvisMembreBien_BienEchange]...';


GO
ALTER TABLE [dbo].[AvisMembreBien]
    ADD CONSTRAINT [FK_AvisMembreBien_BienEchange] FOREIGN KEY ([idBien]) REFERENCES [dbo].[BienEchange] ([idBien]);


GO
PRINT N'Création de [dbo].[FK_AvisMembreBien_membre]...';


GO
ALTER TABLE [dbo].[AvisMembreBien]
    ADD CONSTRAINT [FK_AvisMembreBien_membre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre]);


GO
PRINT N'Création de [dbo].[FK_BienEchange_membre]...';


GO
ALTER TABLE [dbo].[BienEchange]
    ADD CONSTRAINT [FK_BienEchange_membre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre]);


GO
PRINT N'Création de [dbo].[FK_BienEchange_Pays]...';


GO
ALTER TABLE [dbo].[BienEchange]
    ADD CONSTRAINT [FK_BienEchange_Pays] FOREIGN KEY ([Pays]) REFERENCES [dbo].[Pays] ([idPays]);


GO
PRINT N'Création de [dbo].[FK_MembreBienEchange_BienEchange]...';


GO
ALTER TABLE [dbo].[MembreBienEchange]
    ADD CONSTRAINT [FK_MembreBienEchange_BienEchange] FOREIGN KEY ([idBien]) REFERENCES [dbo].[BienEchange] ([idBien]);


GO
PRINT N'Création de [dbo].[FK_MembreBienEchange_membre]...';


GO
ALTER TABLE [dbo].[MembreBienEchange]
    ADD CONSTRAINT [FK_MembreBienEchange_membre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre]);


GO
PRINT N'Création de [dbo].[FK_OptionsBien_BienEchange]...';


GO
ALTER TABLE [dbo].[OptionsBien]
    ADD CONSTRAINT [FK_OptionsBien_BienEchange] FOREIGN KEY ([idBien]) REFERENCES [dbo].[BienEchange] ([idBien]);


GO
PRINT N'Création de [dbo].[FK_OptionsBien_Options]...';


GO
ALTER TABLE [dbo].[OptionsBien]
    ADD CONSTRAINT [FK_OptionsBien_Options] FOREIGN KEY ([idOption]) REFERENCES [dbo].[Options] ([idOption]);


GO
PRINT N'Création de [dbo].[Vue_BiensParPays]...';


GO
CREATE VIEW [dbo].[Vue_BiensParPays]
AS
SELECT     TOP (100) PERCENT idBien, titre, DescCourte, DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal, Photo, AssuranceObligatoire, isEnabled, DisabledDate, Latitude, Longitude, 
                      idMembre, DateCreation
FROM         dbo.BienEchange
ORDER BY Pays
GO
PRINT N'Création de [dbo].[Vue_CinqDernierBiens]...';


GO
CREATE VIEW [dbo].[Vue_CinqDernierBiens]
AS
SELECT     TOP (5) idBien, titre, DescCourte, DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal, Photo, AssuranceObligatoire, isEnabled, DisabledDate, Latitude, Longitude, idMembre, 
                      DateCreation
FROM         dbo.BienEchange
ORDER BY DateCreation DESC
GO
PRINT N'Création de [dbo].[Vue_MeilleursAvis]...';


GO
CREATE VIEW [dbo].[Vue_MeilleursAvis]
AS
SELECT     TOP (100) PERCENT dbo.BienEchange.idBien, dbo.BienEchange.titre, dbo.BienEchange.DescCourte, dbo.BienEchange.DescLong, dbo.BienEchange.NombrePerson, dbo.BienEchange.Pays, 
                      dbo.BienEchange.Ville, dbo.BienEchange.Rue, dbo.BienEchange.Numero, dbo.BienEchange.CodePostal, dbo.BienEchange.Photo, dbo.BienEchange.AssuranceObligatoire, 
                      dbo.BienEchange.isEnabled, dbo.BienEchange.DisabledDate, dbo.BienEchange.Latitude, dbo.BienEchange.Longitude, dbo.BienEchange.idMembre, dbo.BienEchange.DateCreation
FROM         dbo.AvisMembreBien INNER JOIN
                      dbo.BienEchange ON dbo.AvisMembreBien.idBien = dbo.BienEchange.idBien
WHERE     (dbo.AvisMembreBien.note > 6)
ORDER BY dbo.AvisMembreBien.note DESC
GO
PRINT N'Création de [dbo].[sp_RecupBienDispo]...';


GO
-- =============================================
-- Author:		Cognitic 
-- Create date: 28/02/2015
-- Description:	Récupérer les biens disponible entre deux dates
-- =============================================
Create PROCEDURE [dbo].[sp_RecupBienDispo]
	@DateDeb date,
	@DateFin date
AS
BEGIN
	SELECT     *
FROM         BienEchange
where idBien not in (select idBien from MembreBienEchange where 
(@DateDeb >=DateDebEchange and DateFinEchange >= @DateDeb)
or
(DateFinEchange>=@DateFin and DateDebEchange<= @DateFin )
or 
(@DateDeb<=DateDebEchange and DateFinEchange>= @DateFin)
)
END
GO
PRINT N'Création de [dbo].[sp_RecupBienMembre]...';


GO
-- =============================================
-- Author:		Cognitic 
-- Create date: 28/02/2015
-- Description:	Récupérer les biens d'un membre
-- =============================================
CREATE PROCEDURE [dbo].[sp_RecupBienMembre] 
	@idMembre int
AS
BEGIN
	select * from BienEchange
	where idMembre = @idMembre
END
GO
PRINT N'Création de [dbo].[sp_RecupToutesInfosBien]...';


GO
-- =============================================
-- Author:		Cognitic 
-- Create date: 28/02/2015
-- Description:	Récupérer les infos complètes d'un bien à partir de son id
-- =============================================
CREATE PROCEDURE [dbo].[sp_RecupToutesInfosBien] 
	@idBien int
AS
BEGIN
SELECT     *
FROM        BienEchange  left JOIN
                      AvisMembreBien ON AvisMembreBien.idBien = BienEchange.idBien left JOIN
                      Membre ON AvisMembreBien.idMembre = Membre.idMembre AND BienEchange.idMembre = Membre.idMembre left JOIN
                      MembreBienEchange ON BienEchange.idBien = MembreBienEchange.idBien AND Membre.idMembre = MembreBienEchange.idMembre left JOIN
                      OptionsBien ON BienEchange.idBien = OptionsBien.idBien left JOIN
                      Options ON OptionsBien.idOption = Options.idOption left JOIN
                      Pays ON BienEchange.Pays = Pays.idPays
                      where BienEchange.idBien=@idBien
END
GO
PRINT N'Création de [dbo].[Vue_BiensParPays].[MS_DiagramPane1]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BienEchange"
            Begin Extent = 
               Top = 6
               Left = 248
               Bottom = 247
               Right = 439
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Vue_BiensParPays';


GO
PRINT N'Création de [dbo].[Vue_BiensParPays].[MS_DiagramPaneCount]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Vue_BiensParPays';


GO
PRINT N'Création de [dbo].[Vue_CinqDernierBiens].[MS_DiagramPane1]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BienEchange"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 269
               Right = 229
            End
            DisplayFlags = 280
            TopColumn = 5
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Vue_CinqDernierBiens';


GO
PRINT N'Création de [dbo].[Vue_CinqDernierBiens].[MS_DiagramPaneCount]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Vue_CinqDernierBiens';


GO
PRINT N'Création de [dbo].[Vue_MeilleursAvis].[MS_DiagramPane1]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AvisMembreBien"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 219
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BienEchange"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 126
               Right = 427
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Vue_MeilleursAvis';


GO
PRINT N'Création de [dbo].[Vue_MeilleursAvis].[MS_DiagramPaneCount]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Vue_MeilleursAvis';


GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
