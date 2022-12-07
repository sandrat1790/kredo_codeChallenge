ALTER PROC dbo.Cars_Products_SelectAll

AS

/*

	EXECUTE dbo.Cars_Products_SelectAll
	
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
				on cc.[Name] = cp.Make

END