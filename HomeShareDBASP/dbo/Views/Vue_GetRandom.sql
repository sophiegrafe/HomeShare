CREATE VIEW [dbo].[Vue_GetRandom]
	AS SELECT FLOOR(RAND()*10) AS RandomValue
