USE [C118_sandrat1790_gmail]
GO
/****** Object:  StoredProcedure [dbo].[Cars_Categories_SelectAll]    Script Date: 12/7/2022 7:56:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Cars_Categories_SelectAll] 

AS

/*

EXECUTE dbo.Cars_Categories_SelectAll

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

	FROM dbo.Cars_Categories

	ORDER BY Id

END
