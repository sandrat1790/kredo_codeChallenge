ALTER PROC dbo.Cars_Categories_Insert
		  @Name nvarchar(250)
		 ,@Id int OUTPUT
		
AS

/*
	DECLARE @Id int = 0

	DECLARE @Name nvarchar(250) = 'TEST'

	EXECUTE dbo.Cars_Categories_Insert 
			@Name,
			@Id


	SELECT *
	FROM dbo.Cars_Categories
	WHERE Id = @Id




*/


BEGIN

	INSERT INTO dbo.Cars_Categories
		([Name])

	VALUES 
		(@Name)

	SET @Id = SCOPE_IDENTITY()

END
