ALTER PROC dbo.Cars_Products_Delete
		@Id int

AS

/*

	DECLARE @Id int = 6

	SELECT * 
	FROM dbo.Cars_Products
	WHERE Id = @Id

	EXECUTE dbo.Cars_Products_Delete @Id

	SELECT * 
	FROM dbo.Cars_Products


*/

BEGIN 

	DELETE FROM dbo.Cars_Products
	WHERE Id = @Id

END