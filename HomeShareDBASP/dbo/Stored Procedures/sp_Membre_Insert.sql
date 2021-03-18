CREATE PROCEDURE [dbo].[sp_Membre_Insert]
	@login NVARCHAR(64),
	@password NVARCHAR(64),
	@nom NVARCHAR(50),
	@prenom NVARCHAR(50),
	@email NVARCHAR(256),
	@telephone NVARCHAR(20) = NULL,	
	@pays INT
	
	
AS
	DECLARE @IdPerson INT, @salt CHAR(8)
	SET @salt = [dbo].SF_GenerateSalt()	
	INSERT INTO [Membre]([Login],[Password],[Email],[Nom],[Prenom],[Telephone],[Pays],[Salt])	
	VALUES (@login, dbo.sf_PasswordEncryption(@password, @salt), @email, @nom, @nom, @telephone, @pays, @salt)
	
