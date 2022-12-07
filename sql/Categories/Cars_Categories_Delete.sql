ALTER PROC dbo.Cars_Categories_Delete 
		  @Id int
		
AS

/*

	DECLARE @Id int = 11

	SELECT * 
	FROM dbo.Cars_Categories
	WHERE Id = @Id

	EXECUTE dbo.Cars_Categories_Delete
			@Id

	SELECT *
	FROM dbo.Cars_Categories


*/


BEGIN

	
	DELETE FROM Cars_Categories 
		
	WHERE [Id] = @Id
END
