CREATE FUNCTION [dbo].[sf_GenerateSalt]
()
RETURNS CHAR(8)
AS
BEGIN
	DECLARE @saltResult CHAR(8)
	DECLARE @randomValue SMALLINT, @i SMALLINT
	SET @i = 0;
	WHILE @i < 8
	BEGIN
		SET @randomValue = (SELECT RandomValue FROM [Vue_GetRandom])
		SET @saltResult = CONCAT(@saltResult,@randomValue)
		SET @i = @i + 1;
	END

	RETURN @saltResult

END
