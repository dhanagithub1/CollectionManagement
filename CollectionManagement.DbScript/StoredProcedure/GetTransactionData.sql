USE [CollectionManagement]
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionData]    Script Date: 8/5/2018 12:24:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dhanashree Dhabade
-- Create date: 2018-08-04
-- Description:	Get the Transaction Details
-- =============================================
ALTER PROCEDURE [dbo].[GetTransactionData]
	-- Add the parameters for the stored procedure here
	@TransactionId varchar(50)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [CollectionTransactionId]
      ,[TransactionId]
      ,[TransactionStatus]
      ,[ApplicantName]
      ,[MobileNumber]
      ,[Address]
      ,[AadhaarNumber]
      ,[PanNumber]
      ,[ApplicantGSTNumber]
      ,[TotalAmount]
      ,C.[CreatedOn]
      ,C.[CreatedBy]
      ,[ChequeNumber]
      ,[DDNumber]
      ,[BankName]
      ,[BankAddress]
      ,C.[Remarks]
	  ,C.DepartmentId
	  ,D.DepartmentNameEnglish AS DepartmentName
  FROM [dbo].[CollectionTransaction] C
  INNER JOIN Department D
  ON D.DepartmentId=C.DepartmentId
  WHERE [TransactionId]=@TransactionId
END
