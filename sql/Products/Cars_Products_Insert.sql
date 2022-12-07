USE [C118_sandrat1790_gmail]
GO
/****** Object:  StoredProcedure [dbo].[Cars_Products_Insert]    Script Date: 12/6/2022 5:55:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Cars_Products_Insert]
			@Make nvarchar(50)
           ,@Name nvarchar(250)
           ,@Price decimal(18,0)
           ,@Description nvarchar(1500)
		   ,@ImageUrl nvarchar(250)
		   ,@Id int OUTPUT

AS

/*
	DECLARE @id int = 0

	DECLARE @Make nvarchar(50) = 'Lamborghini'
           ,@Name nvarchar(250) = 'Aventador SVJ'
           ,@Price decimal(18,0) = 522948.00
           ,@Description nvarchar(1500) = 'Revolutionary thinking is at the heart of every idea from Automobili Lamborghini. Whether it is aerospace-inspired design or technologies applied to the naturally aspirated V12 engine or carbon-fiber structure, going beyond accepted limits is part of our philosophy. The Aventador advances every concept of performance, immediately establishing itself as the benchmark for the super sports car sector. Giving a glimpse of the future today, it comes from a family of supercars already considered legendary.'
		   ,@ImageUrl nvarchar(250) = 'tinyurl.com/4uwsz3z5'

	EXECUTE dbo.Cars_Products_Insert
			@Make
           ,@Name
           ,@Price
           ,@Description
		   ,@ImageUrl
		   ,@Id

	SELECT *
	FROM dbo.Cars_Products


	





*/

BEGIN

	INSERT INTO [dbo].[Cars_Products]
           ([Make]
           ,[Name]
           ,[Price]
           ,[Description]
		   ,[ImageUrl])
     VALUES
           (@Make
           ,@Name
           ,@Price
           ,@Description
		   ,@ImageUrl)

	 SET @Id = SCOPE_IDENTITY()

END