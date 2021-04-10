CREATE PROCEDURE [dbo].[sp_Bien_Insert]
	@titre NVARCHAR(50),
	@descCourte NVARCHAR(150),
	@descLong NTEXT,
	@numero NVARCHAR(5),
	@rue NVARCHAR(50),
	@codePostal NVARCHAR(50),
	@ville NVARCHAR(50),
	@pays NVARCHAR(50),
	@nombrePerson INT,
	@nbrSBD INT,
	@nbrWC INT,
	@idMembre INT,
	@latitude NVARCHAR(50),
	@longitude NVARCHAR(50),
	@photo NVARCHAR(50)
	
AS
	DECLARE
	@idBien INT
	
	INSERT INTO [BienEchange]([Titre]
			,[DescCourte]
			,[DescLong]
			,[Numero]
			,[Rue]
			,[CodePostal]
			,[Ville]
			,[Pays]
			,[NombrePerson]
			,[NbrWC]
			,[NbrSDB]
			,[IdMembre]
			,[Latitude]
			,[Longitude]
			,[Photo])

	VALUES (@titre,@descCourte,@descLong,@numero,@rue,@codePostal,@ville,@pays,@nombrePerson,@nbrSBD,@nbrWC,@idMembre,@latitude,@longitude,@photo)
	SET @idBien = @@IDENTITY
	
	--dbo.fct_intList_to_tbl(@options,@delim)

	--@xxx = STRING_SPLIT(@options,@delim)
	--SET @valeur = 1


	--INSERT INTO [OptionsBien]([idBien]) --,[idOption]
	--VALUES (@idBien, dbo.sf_splitOption(@options)) --,@idOption


RETURN 0
