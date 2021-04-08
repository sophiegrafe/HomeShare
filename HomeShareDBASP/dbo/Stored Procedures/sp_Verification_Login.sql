CREATE PROCEDURE [dbo].[sp_Verification_Login]
	@login VARCHAR (64),
	@password NVARCHAR(64)
	
AS
	DECLARE @hPassword NVARCHAR(500)
	DECLARE @salt CHAR(8)
	DECLARE @newPassword NVARCHAR(500)
	SELECT @salt = Salt, @hPassword = [Password] FROM Membre WHERE login = @login
	SELECT @newPassword = dbo.sf_PasswordEncryption (@password, @salt)
	
	IF (@newPassword = @hPassword)
	BEGIN 		
	SELECT [Login], Nom, Prenom, Email, Telephone, Pays, IdMembre
	FROM Membre 
	
	END 
