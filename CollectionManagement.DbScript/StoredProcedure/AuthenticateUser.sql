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
-- Create date: 2018-08-02
-- Description:	Authenticate user after login
-- =============================================
Alter PROCEDURE [dbo].[AuthenticateUser] 
	-- Add the parameters for the stored procedure here
	@Username varchar(20) = NULL, 
	@PasswordString varchar(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT		U.UserId
				,U.FirstName
				,U.LastName
				,U.MobileNumber
				,U.EmailAddress
				,U.RoleId			
				,U.CreatedOn
				,U.CreatedBy
				,U.IsActive
				,R.RoleName
	FROM		[dbo].[User] U
	INNER JOIN	[dbo].[Role] R
	ON			U.RoleId		=R.RoleId
	WHERE		Username		=@Username
	AND			[Password]		=@PasswordString

END
GO
