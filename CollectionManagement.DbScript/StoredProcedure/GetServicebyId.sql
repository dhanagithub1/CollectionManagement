USE [CollectionManagement]
GO
/****** Object:  StoredProcedure [dbo].[GetAllServices]    Script Date: 8/6/2018 10:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dhanashree D
-- Create date: 2018-08-06
-- Description:	Get the service details per id from DB
-- =============================================
CREATE PROCEDURE [dbo].[GetServicebyId] 
	-- Add the parameters for the stored procedure here
	@ServiceId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	[ServiceId]
			,[ServiceNameEnglish]
			,[ServiceNameMarathi]
			,[FunctionCode]
			,[ObjectCode]
			,[DepartmentId]
			,[IsActive]
			,[CreatedOn]
			,[CreatedBy]
  FROM		[dbo].[Service]
  WHERE		@ServiceId			=[ServiceId]

END
