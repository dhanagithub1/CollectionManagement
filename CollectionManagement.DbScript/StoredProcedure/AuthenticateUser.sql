USE [CollectionManagement]
GO
/****** Object:  StoredProcedure [dbo].[AuthenticateUser]    Script Date: 8/5/2018 12:24:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dhanashree D
-- Create date: 2018-08-02
-- Description:	Authenticate user after login
-- =============================================
ALTER PROCEDURE [dbo].[AuthenticateUser] 
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
				,D.DepartmentNameEnglish as DepartmentName
				,U.[DepartmentId]
	FROM		[dbo].[User] U
	INNER JOIN	[dbo].[Role] R
	ON			U.RoleId		=R.RoleId
	LEFT JOIN	[dbo].[Department] D
	ON			U.[DepartmentId]		=D.[DepartmentId]
	WHERE		Username		=@Username
	AND			[Password]		=@PasswordString

END
