ALTER PROC dbo.Cars_Products_SelectByMake
		@Make nvarchar(50)

AS

/*

	DECLARE @Make nvarchar(50) = 'Lamborghini'

	EXECUTE dbo.Cars_Products_SelectByMake @Make



*/

BEGIN

	SELECT 
	   cp.[Id]
      ,[Make]
      ,cp.[Name]
      ,[Price]
      ,[Description]
      ,[ImageUrl]

  FROM [dbo].[Cars_Products] as cp
			inner join dbo.Cars_Categories as cc
				on cp.Make = cc.Name

	WHERE [Make] = @Make

END
