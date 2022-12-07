ALTER PROC dbo.Cars_Products_Update
			@Make nvarchar(50)
           ,@Name nvarchar(250)
           ,@Price decimal(18,0)
           ,@Description nvarchar(1500)
		   ,@ImageUrl nvarchar(250)
		   ,@Id int

AS

/*
	DECLARE @id int = 3

	DECLARE @Make nvarchar(50) = 'Lamborghini'
           ,@Name nvarchar(250) = 'Urus S'
           ,@Price decimal(18,0) = 409644.98
           ,@Description nvarchar(1500) = 'Lamborghini Urus is the first Super Sport Utility Vehicle in the world, merging the soul of a super sports car with the practical functionality of an SUV. Powered by Lamborghini’s 4.0-liter twin-turbo V8 engine, the Urus is all about a performance mindset that brings together fun-to-drive and astounding vehicle capabilities. The design, performance, driving dynamics and unbridled emotion flow effortlessly into this visionary realization of authentic Lamborghini DNA.'
		   ,@ImageUrl nvarchar(250) = 'tinyurl.com/bdz5zuw9'

	SELECT *
	FROM dbo.Cars_Products
	WHERE Id = @Id

	EXECUTE dbo.Cars_Products_Update
			@Make
           ,@Name
           ,@Price
           ,@Description
		   ,@ImageUrl
		   ,@Id

	SELECT *
	FROM dbo.Cars_Products
	WHERE Id = @Id


*/

BEGIN

	UPDATE [dbo].[Cars_Products]
		SET
           [Make] = @Make
           ,[Name] = @Name
           ,[Price] = @Price
           ,[Description] = @Description
		   ,[ImageUrl] = @ImageUrl

     WHERE Id = @Id

END