-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dhanashree D
-- Create date: 2018-08-03
-- Description:	Get the Department List
-- =============================================
CREATE PROCEDURE [dbo].[GetAllDepartments] 
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT	[DepartmentId]
			,[DepartmentNameEnglish]
			,[DepartmentNameMarathi]
			,[CreatedOn]
			,[CreatedBy]
			,[IsActive]
	FROM	[dbo].[Department]
END
GO
