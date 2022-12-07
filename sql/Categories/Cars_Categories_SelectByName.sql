USE [C118_sandrat1790_gmail]
GO
/****** Object:  StoredProcedure [dbo].[Cars_Categories_SelectByName]    Script Date: 12/7/2022 8:15:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Cars_Categories_SelectByName]
		  @Name nvarchar(250)
		
AS

/*

	DECLARE @Name nvarchar(250) = 'BMW'

	EXECUTE dbo.Cars_Categories_SelectByName
			@Name


*/


BEGIN

	SELECT 
		 [Id]
		,[Name]
		,Products = (SELECT cp.Id
							,cp.Make
							,cp.Name
							,cp.Price
							,cp.[Description]
							,cp.ImageUrl
					 FROM dbo.Cars_Products as cp 
					 WHERE cp.Make = dbo.Cars_Categories.[Name]
					 FOR JSON AUTO)

	FROM Cars_Categories
		
	WHERE [Name] = @Name
END
