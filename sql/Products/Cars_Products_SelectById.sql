ALTER PROC dbo.Cars_Products_SelectById
		@Id int
		
AS

/*

	DECLARE @Id int = 12

	EXECUTE dbo.Cars_Products_SelectByid
			@Id


*/


BEGIN

	SELECT 
		 [Id]
		,[Make]
		,[Name]
		,[Price]
		,[Description]
		,[ImageUrl]

	FROM Cars_Products
		
	WHERE [Id] = @Id
END
