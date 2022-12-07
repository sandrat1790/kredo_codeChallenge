USE [C118_sandrat1790_gmail]
GO
/****** Object:  StoredProcedure [dbo].[Cars_Categories_SelectById]    Script Date: 12/7/2022 8:11:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Cars_Categories_SelectById] 
		  @Id int
		
AS

/*

	DECLARE @Id int = 8

	EXECUTE dbo.Cars_Categories_SelectById
			@Id


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
		
	WHERE [Id] = @Id
END
