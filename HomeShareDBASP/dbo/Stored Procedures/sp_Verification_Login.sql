--CREATE PROCEDURE [dbo].[sp_Verification_Login]
--	@login VARCHAR (64),
--	@password NVARCHAR(64)
	
--AS
--	DECLARE @hPassword VARBINARY(32)
--	DECLARE @salt CHAR(8)
--	DECLARE @newPassword VARBINARY(32)
--	SELECT @salt = Salt, @hPassword = [Password] FROM Membre WHERE login = @login
--	SELECT @newPassword = dbo.sf_PasswordEncryption (@password, @salt)
	
--	IF (@newPassword = @hPassword)
--	BEGIN 		
--	SELECT [Login], Nom, Prenom, Email, IdMembre
--	FROM Membre 
	
--	END 
