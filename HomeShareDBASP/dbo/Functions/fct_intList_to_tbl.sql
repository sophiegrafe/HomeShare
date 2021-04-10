CREATE FUNCTION [dbo].[fct_intList_to_tbl]
(@options nvarchar(MAX), @delim nvarchar(10))
   RETURNS @tbl TABLE (listpos int NOT NULL IDENTITY(1,1),
                       n       int NULL) AS
BEGIN
   DECLARE @pos       int = 1,
           @nextpos   int = 1,
           @valuelen  int,
           @delimlen  int = datalength(@delim) / 2

   WHILE @nextpos > 0
   BEGIN
      SELECT @nextpos = charindex(@delim COLLATE Czech_BIN2, @options, @pos)
      SELECT @valuelen = CASE WHEN @nextpos > 0 THEN @nextpos
                              ELSE len(@options) + 1
                         END - @pos
      INSERT @tbl (n)
         VALUES (convert(int, nullif(substring(@options, @pos, @valuelen), '')))
      SELECT @pos = @nextpos + @delimlen
   END
   RETURN
END
