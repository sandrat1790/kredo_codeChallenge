ALTER PROC dbo.Cars_Categories_Update 
		 @Name nvarchar(250)
		,@Id int

AS

/*
	DECLARE @Id int = 8

	DECLARE @Name nvarchar(250) = 'Mercedes'

	SELECT *
	FROM dbo.Cars_Categories
	WHERE Id = @Id

	EXECUTE dbo.Cars_Categories_Update
		 @Name
		,@Id

	SELECT *
	FROM dbo.Cars_Categories
	WHERE Id = @Id


*/

BEGIN

	UPDATE dbo.Cars_Categories
		SET [Name] = @Name

	WHERE Id = @Id

END